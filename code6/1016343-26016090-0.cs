    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                XDocument document = XDocument.Load(@"C:\Users\amit\SkyDrive\code\WebApplication1\ConsoleApplication1\xml.xml");
                XElement root = new XElement("sentiment");
                root.Value = "3";
                root.Add(new XAttribute("word", "napustiti"));
                XNamespace nsSys = "RecnikSema.xsd";
                document.Element(nsSys + "dictionary").Element(nsSys + "sentiments").Add(root);
                document.Save("c:\newFile.xml");
            }
        }
    }
