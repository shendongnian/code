    public static class XmlNamespaces
    {
        public const string Default = "http://MyCompany.com/MySchema.xsd";
        public const string xsi = "http://www.w3.org/2001/XMLSchema-instance";
        public const string xsd = "http://www.w3.org/2001/XMLSchema";
        public static XmlSerializerNamespaces XmlSerializerNamespaces
        {
            get
            {
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", XmlNamespaces.Default);
                namespaces.Add("xsi", XmlNamespaces.xsi);
                namespaces.Add("xsd", XmlNamespaces.xsd);
                return namespaces;
            }
        }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = XmlNamespaces.Default)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = XmlNamespaces.Default, IsNullable = false)] // Added this and used const string from XmlNamespaces class
    public partial class Level1
    {
        private List<Level2> level2Field;
        public List<Level2> Level2Field
        {
            get { return this.level2Field; }
            set { this.level2Field = value; }
        }
        /* other properties on Level1 go here*/
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = XmlNamespaces.Default)] // Used const string  from XmlNamespaces class
    public partial class Level2
    {
        /* properties on Level2 go here*/
    }
    public static class XmlSerializationUtilities
    {
        public static void WriteList<TItem>(string rootName, XmlSerializerNamespaces namespaces, IEnumerable<TItem> list, TextWriter textWriter)
        {
            var namespaceList = namespaces.ToArray();
            string defaultNamespace = null;
            foreach (var ns in namespaceList)
            {
                if (string.IsNullOrEmpty(ns.Name))
                {
                    defaultNamespace = ns.Namespace;
                    break;
                }
            }
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "    ";
            using (var writer = XmlWriter.Create(textWriter, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("RootLevel", defaultNamespace);
                foreach (var ns in namespaceList)
                    if (!string.IsNullOrEmpty(ns.Name))
                        writer.WriteAttributeString("xmlns", ns.Name, null, ns.Namespace);
                var serializer = new XmlSerializer(typeof(TItem));
                foreach (var item in list)
                {
                    serializer.Serialize(writer, item);
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
    public static class TestClass
    {
        public static void Test()
        {
            var list = new List<Level1> { new Level1 { Level2Field = new List<Level2> { new Level2(), new Level2() } }, new Level1 { Level2Field = new List<Level2> { new Level2(), new Level2(), new Level2(), new Level2() } } };
            string xml;
            using (var writer = new StringWriter())
            {
                XmlSerializationUtilities.WriteList("RootLevel", XmlNamespaces.XmlSerializerNamespaces, list, writer);
                xml = writer.ToString();
                Debug.WriteLine(xml);
            }
        }
    }
