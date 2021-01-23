    [Serializable()]
    [XmlRoot(ElementName = "row")]
    public class ProductAttribute
    {
        [XmlAttribute("flag")]
        public string Flag { get; set; }
        [XmlAttribute("sect")]
        public string Sect { get; set; }
        [XmlAttribute("header")]
        public string Header { get; set; }
        [XmlAttribute("body")]
        public string Body { get; set; }
        [XmlAttribute("extrainfo")]
        public string Extrainfo { get; set; }
    }
