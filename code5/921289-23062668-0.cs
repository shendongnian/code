    public class Entry
    {
        [XmlAttribute("key")]
        public string Key { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
    
    [Serializable]
    [XmlRoot(ElementName = "xml")]
    public class MyXml
    {
        [XmlArray(ElementName = "metadata")]
        [XmlArrayItem(ElementName = "entry")]
        public List<Entry> Metadata { get; set; }
    }
