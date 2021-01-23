    public class Program
    {
        static void Main(string[] args)
        {
            Metadata meta = new Metadata();
            meta.entry = new List<Entry>();
            var dim = new dimensionInfo();
            meta.entry.Add(
                new Entry()
                {
                    key = "",
                    O = dim
                }
                );
            meta.entry.Add(
                new Entry()
                {
                    key = "",
                    text = "false",
                    O = null
                }
                );
            XmlWriterSettings set = new XmlWriterSettings();
            set.NamespaceHandling = NamespaceHandling.OmitDuplicates;
            set.OmitXmlDeclaration = true;
            set.DoNotEscapeUriAttributes = false;
            set.Indent = true;
            set.NewLineChars = "\n\r";
            set.IndentChars = "\t";
            XmlWriter writer = XmlWriter.Create(Console.Out, set);
            XmlSerializer ser = new XmlSerializer(typeof(Metadata), "");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            ser.Serialize(writer, meta, namespaces);
        }
        [XmlRoot("metadata")]
        public class Metadata
        {
            [XmlElement]
            public List<Entry> entry;
        }
        public class dimensionInfo
        {
            [XmlElement]
            public bool enabled = false;
        }
        public class Entry
        {
            [XmlAttribute] // serialized as attribute
            public string key = "";
            [XmlText] // serialized as text node
            public string text = "";
            [XmlElement("dimensionInfo")] // serialized as an element
            public dimensionInfo O = null;
        }
    }
