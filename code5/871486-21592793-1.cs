    [XmlRoot("markers")]
    public class EventList
    {
        [XmlElement("marker")]
        public List<EventClass> EventClasses {get; set;}
    }
    
    
    public class EventClass
    {
        public int id {get; set;}
        public string name {get; set;}
        public string address {get; set;}
        public string type {get; set;}
    }
