    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    
    
    namespace XMLdata
    {
        class Program
        {
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load("c:\\somexmlfile.xml");
                 XmlDocument doc1 = new XmlDocument();
                    doc1.LoadXml (doc.ToString());
                    XmlElement element = doc1.DocumentElement;
                    XmlNode node= element.ChildNodes[0];
    
                double value = double.Parse(node.InnerText);
            }
        }
    }
