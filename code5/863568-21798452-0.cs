    using System;
    using System.IO;
    using System.Xml.Serialization;
    namespace XMLNamespaceChangeSerialization
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var serialize = Serialize();
                Console.WriteLine(serialize);
                Console.ReadLine();
            }
            private static string Serialize()
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("env", "httpenv");
                // Don't add it here, otherwise it will be defined at the root element
                // ns.Add("sos", "httpsos");
                var stringWriter = new StringWriter();
                var serializer = new XmlSerializer(typeof (RootClass), new XmlAttributeOverrides(), new Type[]{},  new XmlRootAttribute("root"), "httpenv");
                serializer.Serialize(stringWriter, new RootClass(), ns);
                return stringWriter.ToString();
            }
        }
    
        [Serializable]
        public class RootClass
        {
            [XmlElement(ElementName = "body", Namespace = "httpenv")]
            public BodyClass body = new BodyClass();
        }
        [Serializable]
        public class BodyClass
        {
            // Note: you can't specify the prefix using ElementName="sos:element"
            // So the default namespace will be redefined here
            [XmlElement( ElementName = "element", Namespace = "httpsos")]
            public SOSClass element = new SOSClass();
        }
        [Serializable]
        public class SOSClass
        {
        }
    }
