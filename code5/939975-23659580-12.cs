    [XmlRoot(ElementName = "B")]
    public class ParameterB
    {
        [XmlElement("C")]
        public string Label { get; set; }
    
        [XmlElement("D")]
        public string Type  { get; set; }
    }
