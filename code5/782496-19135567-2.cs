    [XmlRoot("XmlFile")]
    public class SerializableContainer
    {
        [XmlElement("OBJECTS")]
        public SerializeObject[] Objects { get; set; }
    }
    public class SerializeObject
    {
        [XmlAttribute("ITEM")]
        public string Item { get; set; }
        [XmlAttribute("TABLE_NAME")]
        public string Table_Name { get; set; }
    }
