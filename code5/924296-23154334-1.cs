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
		
        public Services Services { get; set; }
		
        public Options Options { get; set; }
    }
	
    public class Services
	{
	    public string Open { get; set; }
	}
	
	public class Options
    {
	    public string mail { get; set; }
	}
