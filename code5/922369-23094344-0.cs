    public class FieldServers
    {
    	[XmlElement] //add this line
        public List<FieldServer> FieldServer = new List<FieldServer>();
    }
    
    public class FieldServer
    {
        [XmlAttribute("ID")]
        public string ID { get; set; }
    	
    	[XmlElement("Item")] //add this line
        public List<Item> EntryPoints = new List<Item>();
    }
