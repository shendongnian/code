    class Program
        {
            static void Main(string[] args)
            {
                XmlAttributes attrs = new XmlAttributes();
    
                XmlElementAttribute attr = new XmlElementAttribute();
                attr.ElementName = "DerivedClass";
                attr.Type = typeof(DerivedClass);
    
                attrs.XmlElements.Add(attr);
    
                XmlAttributeOverrides attrOverrides = new XmlAttributeOverrides();
    
                attrOverrides.Add(typeof(MainObject), "TheBase", attrs);
    
                XmlSerializer s = new XmlSerializer(typeof(MainObject), attrOverrides);
    
                StringWriter writer = new StringWriter();
    
                MainObject mo = new MainObject { TheBase = new DerivedClass { AnAttribute = "AnAttribute", AnElement = "AnElement", AnotherElement = "AotherElement" } };
    
                s.Serialize(writer, mo);
                Console.Write(writer.ToString());
            }
        }
