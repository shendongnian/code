        [XmlRoot("metadata")]
        public class Metadata
        {
            [XmlElement]
            public List<Entry> entry;
        }
        public class dimensionInfo
        {
            public bool enabled = false;
        }
        public class Entry
        {
            [XmlAttribute]
            public string key = "";
            [XmlText]
            public string text = "";
            [XmlElement(Namespace="")]
            public object O;
        }
