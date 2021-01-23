    using System;
    using System.Xml.Linq; 
    
    public class Test
    {
        static void Main()
        {
            var doc = new XDocument(
                new XElement("root",
                    new XElement("value1", "This is a value"),
                    new XElement("value2", "This is another value")));
            
            Console.WriteLine(doc);
            
            XElement value2 = doc.Root.Element("value2");
            value2.ReplaceWith(new XComment(value2.ToString()));
            Console.WriteLine(doc);
        }
    }
