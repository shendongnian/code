    public class Document
    {
        [XmlAttribute]
        public string Value { get; set; }
    }
    [XmlRoot("ROOT")]
    public class Root
    {
        [XmlElement("DOC")]
        public List<Document> Documents { get; set; }
    }
