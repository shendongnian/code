    [XmlRoot("results")]
    public class StandardAddress
    {
        [XmlElement(ElementName = "dpv_answer")]
        public dpv_answer dpv_answer { get; set; }
        [XmlElement(ElementName = "zip")]
        public zip zip { get; set; }
    }
    public class dpv_answer
    {
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
    public class zip
    {
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
