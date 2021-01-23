    [XmlRoot("attributes")]    
    public class Attributes
    {
        [XmlElement("value")]
        public byte Value { get; set; }
        [XmlElement("showstatus")]
        public string ShowStatus { get; set; }        
        
        [XmlArray("disableothers")]
        [XmlArrayItem("disableother", IsNullable = false)]
        public DisableOther[] DisableOthers { get; set; }
    }
    
    [XmlRoot("disableOther")]
    public class DisableOther
    {
        [XmlElement("disablevalue")]
        public byte DisableValue { get; set; }
        [XmlElement("todisable")]
        public string[] ToDisable { get; set; }
    }
