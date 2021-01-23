    public class Outbound
    {
        [XmlElement(ElementName = "leg0",typeof(Leg)]
        [XmlElement(ElementName = "leg1",typeof(Leg))]
        public List<Leg> Leg { get; set; }
    }
