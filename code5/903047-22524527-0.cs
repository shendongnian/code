    public class SpellResult
    {
	  [XmlElement("error")]
      public List<Error> Errors { get; set; }
    }
	
    public class Error
    {
        [XmlAttribute("code")]
        public int Code { get; set; }
		
        [XmlAttribute("pos")]
        public int Position { get; set; }
		
        [XmlAttribute("row")]
        public int Row { get; set; }
        [XmlAttribute("col")]
        public int Column { get; set; }
		
        [XmlAttribute("len")]
        public int Length { get; set; }
		
        [XmlElement("word")]
        public string Word { get; set; }
       
		[XmlElement("s")]
        public List<Steer> Steers { get; set; }
    }
    public class Steer
    {
		[XmlText]
        public string S { get; set; }
    } 
