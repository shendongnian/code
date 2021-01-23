    [XmlRoot(ElementName = "A")]
    public class ParameterA
    {
        [XmlElement("B")]
        public ParameterB B { get; set; }
    }
