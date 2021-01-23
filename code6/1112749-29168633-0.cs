    public class Address
    {
        [XmlAttribute(AttributeName = "tempid")]
        public string TempId { get; set; }
        [XmlText]
        public string FullAddress { get; set; }
    }
