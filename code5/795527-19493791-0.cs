    public class recipients
    {
        [XmlElement("gsm")]
        public List<gsm> gsm { get; set; }
    
        public recipients()
        {
            gsm = new List<gsm>();
        }
    }
    
    public class gsm
    {
        [XmlText]
        public string number { get; set; }
    
        [XmlAttribute]
        public string messageId { get; set; }
    }
