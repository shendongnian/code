    public class Unit
    {
    	[XmlAttribute]
        public string Name { get; set; }
    	
    	[XmlAttribute]
        public string ID { get; set; }
    }
    
    public class Produced_by
    {
        public Unit Unit { get; set; }
    }
