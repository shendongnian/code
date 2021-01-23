    public class Entry
    {
        [XmlAttribute("key")]
        public string Key { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
    [XmlRoot(ElementName="xml")]
    public class MyXml
    {
        [XmlArray("metadata")]
        [XmlArrayItem("entry")]
        public List<Entry> Metadata { get; set; }
    }
    
