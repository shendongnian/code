    public class ObjectXml
    {
        [XmlArray("People"), XmlArrayItem("Person")]
        public List<PersonXml> People { get; set; }
        //PersonXml is an xml data model similar to this one
    
        [XmlElement("Item")]
        public string Items { get; set; }
    }
