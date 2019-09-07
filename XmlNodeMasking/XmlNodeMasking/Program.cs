using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlNodeMasking
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private static void getXMLNode()
        {
            XDocument xml = XDocument.Load("C:/ConsioleProject/YieldProg/YieldProg/dataItem.xml");
            XElement el1 = xml.Root;
            XElement el2 = xml.Element("documentIdentification");

            //foreach (var node in xml.DescendantNodes().OfType<XText>())
            //{
            //    var value = node.Value.Trim();

            //    if (!string.IsNullOrEmpty(value))
            //    {
            //        Console.WriteLine(value);
            //        //some code...
            //    }
            //}  

            var redactedElements = new HashSet<XName>
                {
                  "number",
                  "givenName"
                };

            // List<XElement> elements = new List<XElement>();
            //IEnumerable<XElement> childList = from el in xml.Descendants().Where(a=> a.Element("number"))
            //                                  select el;
            foreach (XNode node in xml.DescendantNodes())
            {
                if (node is XElement)
                {
                    XElement element = (XElement)node;
                    //XElement hash = element.Element("documentIdentification").Element("number");

                    var elements = element.Descendants()
                              .Where(a => redactedElements.Contains(a.Name.LocalName))
                              .ToList();

                    foreach (var el in elements)
                    {
                        //var num = el.Descendants("number").Where(a => a.Parent.Name == "documentIdentification");
                        el.Value = new string('*', el.Value.Length);
                    }

                    //if (element.Name.LocalName.Equals("documentIdentification"))
                    //{
                    //    //string c1 = (string)element.Name.LocalName("number");
                    //    var eg = element.Descendants("number");
                    //    var elements = element.Descendants()
                    //          .Where(a => redactedElements.Contains(a.Name.LocalName))
                    //          .ToList();

                    //    foreach (var el in elements)
                    //    {
                    //        el.Value = new string('*', el.Value.Length);
                    //    }
                    //}
                }
            }
        }


    }
}
