    [XmlType("file")]
    public class File
    {
        [XmlElement("id")]
        public string Id { get; set; }
        [XmlElement("company_name")]
        public string Company_Id { get; set; }
        [XmlArray("docs")]
        public HashSet<Doc> Docs { get; set; }
    }
    [XmlType("doc")]
    public class Doc
    {
        [XmlElement("valA")]
        public string ValA { get; set; }
        [XmlElement("valB")]
        public string ValB { get; set; }
    }
