    public class Program
    {
        public static void Main()
        {
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            overrides.Add(typeof(MyClass), "DontSerializeMeEvenThoughImPublic", new XmlAttributes { XmlIgnore = true });
            overrides.Add(typeof(MyClass), "SerializeMeAsXmlAttribute", new XmlAttributes { XmlAttribute = new XmlAttributeAttribute("another_name") });
            XmlSerializer serializer = new XmlSerializer(typeof(MyClass), overrides);
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, new MyClass());
                Console.WriteLine(writer.ToString());
            }
        }
    }
