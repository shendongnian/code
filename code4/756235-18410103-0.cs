    [XmlRoot("results")]
    public class StandardAddress
    {
        [XmlElement(ElementName = "dpv_answer")]
        public Answer dpv_answer { get; set; }
    
    }
    
    public class Answer
    {
    
        [XmlAttribute("value")]
        public string Value{ get; set; }
    
        [XmlElement(ElementName = "zip")]
        public string zip { get; set; }
    }
