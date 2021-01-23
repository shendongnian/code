    [Serializable]
    [XmlRoot("root")]
    public class RootClass
    {
        [XmlElement("key")]
        public List<KeyClass> key { get; set; }
    }
    
    [Serializable]
    [XmlType("key")]
    public class KeyClass
    {
        [XmlElementAttribute("value")]
        public string KeyValue { get; set; }
    
        [XmlElement("Index")]
        public List<int> index { get; set; }
    }
