    public class Move 
    {
    	[XmlElement(Order = 1)]
        public string MoveName {get; set;}
    	
    	[XmlElement(Order = 2, ElementName = "Tags")]
        public List<Tag> oTags = new List<Tag>();
    }
    
    public class Tag 
    {
    	[XmlText]
        public string TagName {get; set;}
    }
