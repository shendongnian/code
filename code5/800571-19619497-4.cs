    [XmlRoot("feed", Namespace = "http://www.w3.org/2005/Atom")]
        public class entry
        {
            [XmlAttribute("itemNum", Namespace = "http://www.live.com/marketplace")]
            public int itemNum { get; set; }
    
            public string title { get; set; }
            
            [XmlElement("media" Namespace="http://www.live.com/marketplace")]
            public media media{ get; set; }
        }
