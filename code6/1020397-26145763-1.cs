    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {    
        static void Main()
        {
            XName valuesName = "entry";
            var dictionary = new Dictionary<string, string>
            {
                { "A", "B" },
                { "Foo", "Bar" }
            };
            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("root",
                    dictionary.Select(kvp => new XElement(valuesName,
                                                   new XAttribute("key", kvp.Key),
                                                   new XAttribute("value", kvp.Value)))));
            doc.Save("test.xml");
        }
    }
