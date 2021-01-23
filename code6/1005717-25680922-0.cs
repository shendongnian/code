    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Xml.Linq;
    using System.Xml.XPath;
    class Program
    {
        class Children
        {
            public string one { get; set; }
            public string two { get; set; }
        }
        static void Main(string[] args)
        {
            string xmlstr = @"<?xml version=""1.0"" encoding=""utf-8""?>
    <rootelement>
      <childone>val1</childone>
      <childtwo>val2</childtwo>
      <childthree>val3</childthree>
      <children1>
        <children2>
          <one>val1-1</one>
          <two>val1-2</two>
          <three>val1-3</three>
        </children2>
      </children1>
    </rootelement>";
            XDocument xml = XDocument.Parse(xmlstr);
            string[] fieldnames = { "childone", "childtwo", "childthree" };
            List<KeyValuePair<string, string>> fields = new List<KeyValuePair<string, string>>();
            foreach (string i in fieldnames)
            {
                XElement elem = xml.Root.XPathSelectElement(i);
                if (elem != null)
                {
                    fields.Add(new KeyValuePair<string, string>(i, elem.Value));
                }
            }
            // Debug
            foreach (KeyValuePair<string, string> f in fields)
            {
                Console.WriteLine(f);
            }
            // Try to fill specific object's properties with using reflection
            
            string parentPath = "children1/children2";
            string[] names = { "one", "two", "three" };
            Children childrenFields = new Children();
            foreach (var name in names)
            {
                PropertyInfo prop = typeof(Children).GetProperty(name);
                if (prop != null)
                {
                    XElement elem = xml.Root.XPathSelectElement(parentPath + "/" + name);
                    if (elem != null)
                    {
                        prop.SetValue(childrenFields, elem.Value, null);
                    }
                }
            }
            // Debug
            Console.WriteLine("Children one: {0}, two: {1}",
                childrenFields.one, childrenFields.two);
        }
    }
