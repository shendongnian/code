    public class Family : IXmlSerializable
    {
        public List<ChildAge> childAges { get; set; }
        public void WriteXml(XmlWriter writer)
        {
            foreach(ChildAge ca in childAges)
                writer.WriteElementString("Age", ca.Age.ToString());
        }
        public void ReadXml(XmlReader reader)
        {
            // [...]
        }
        public XmlSchema GetSchema()
        {
            return (null);
        }
    }
    public class ChildAge
    {
        public int Age { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Family f = new Family();
            f.childAges = new List<ChildAge>();
            f.childAges.Add(new ChildAge() { Age = 10 });
            f.childAges.Add(new ChildAge() { Age = 8 });
            XmlSerializer xs = new XmlSerializer(typeof(Family));
            XmlSerializerNamespaces xmlnsEmpty;
            xmlnsEmpty = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.Indent = true;
            writerSettings.OmitXmlDeclaration = true;
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlTextWriter.Create(sb, writerSettings);
            xs.Serialize(writer, f, xmlnsEmpty);
            Console.WriteLine(sb.ToString());
            Console.ReadLine();
        }
    }
