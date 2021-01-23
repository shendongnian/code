    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml;
    using System.Xml.Serialization;
    namespace Demo
    {
        [Serializable]
        public class Test
        {
            public string Text;
            public int    Number;
        }
        internal class Program
        {
            private static void Main()
            {
                var test = new Test {Text = "Some text", Number = 12345 };
                // Creates a binary file:
                using (var stream = File.Create(@"c:\\test\\test.bin"))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, test);
                }
                // Creates an XML file using XmlSerializer:
                using (var stream = File.Create(@"c:\\test\\test1.xml"))
                {
                    var formatter = new XmlSerializer(typeof(Test), defaultNamespace : "");
                    formatter.Serialize(stream, test);
                }
                // Creates an XML file using XmlWriter and DataContractSerializer:
                DataContractSerializer serializer = new DataContractSerializer(test.GetType());
                using (var streamWriter = File.CreateText(@"c:\\test\\test2.xml"))
                using (var xmlWriter    = XmlWriter.Create(streamWriter, new XmlWriterSettings { Indent = true }))
                {
                    serializer.WriteObject(xmlWriter, test);
                }
            }
        }
    }
