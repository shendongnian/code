    using System;
    using System.Xml.Linq;
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                XDocument xDoc = new XDocument(
                       new XDeclaration("1.0", "UTF-8", "yes"),
                       new XElement("Mail"));
                var template = @"To MOM 
                13, AD1
                tr y
                fghdh, Madhya Pradesh, India 
                Dear Ram,
                      We would like to appoint you for new job";
                XElement varXElement = new XElement("studentName", template);
                xDoc.Element("Mail").Add(varXElement);
                xDoc.Save("C:\\doc.xml");
                Console.ReadLine();
            }
        }
    }
