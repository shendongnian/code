    public class ModelA
    {
        public int Foo { get; set; }
    }
    public class ModelB
    {
        public string Bar { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var stream = new MemoryStream();
            var writer = XmlWriter.Create(stream);
            var list = new List<object>() 
            {
                new ModelA() { Foo = 9 },
                new ModelB() { Bar = "some string" }
            };
            writer.WriteStartElement("root");
            list.ForEach(x => ToXml(x, writer));
            writer.WriteEndElement();
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            var doc = new XmlDocument();
            doc.Load(XmlReader.Create(stream));
            Console.WriteLine(doc.OuterXml);
            Console.ReadLine();
        }
        private static void ToXml(object obj, XmlWriter writer)
        {
            var serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(writer, obj);
        }
    }
