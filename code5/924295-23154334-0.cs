    public class LabelRequest
    {
        [XmlAttribute]
        public string Test { get; set; }
    	
        [XmlAttribute]
        public string LabelType { get; set; }
    	
        [XmlAttribute]
        public string LabelSubtype { get; set; }
    	
        [XmlAttribute]
        public string LabelSize { get; set; }
    	
        [XmlAttribute]
        public string ImageFormat { get; set; }
    	
    	public string MailpieceShape { get; set; }
    }
