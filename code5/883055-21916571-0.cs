    using System;
    using System.Linq;
    using System.Xml.Linq;
    public class XmlToList
    {
        static void Main()
        {
            string xml = "<Customers><customer ID=\"0\" firstname=\"xx\" lastname=\"xx\" />/Customers>";
            XDocument doc = XDocument.Parse(xml);
            var list = doc.Root.Elements("Customers")
                           .Select(node => node.Value)
                           .ToList();
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
