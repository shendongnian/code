    [XmlRoot(ElementName = "A")]
    public class ParameterA
    {
        [XmlElement("B")]
        public List<ParameterB> B { get; set; }
    }
