    public class Skill
    {
        [XmlElement(ElementName = "Cast")]
        public int Cast { get; set; }
        [XmlElement(ElementName = "ReCast")]
        public int ReCast { get; set; }
        [XmlElement(ElementName = "MPCost")]
        public int MpCost { get; set; }
    }
