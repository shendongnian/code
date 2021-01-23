    [XmlRoot("results")]
    public class StandardAddress
    {
        [XmlElement(ElementName = "dpv_answer")]
        public Element DpvAnswer { get; set; }
        [XmlElement(ElementName = "zip")]
        public Element Zip { get; set; }
    }
    public class Element
    {
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
