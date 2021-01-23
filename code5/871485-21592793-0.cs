    [XmlRoot("markers")]
    public class MarkerList
    {
        [XmlElement("marker")]
        public Marker[] Markers {get; set;}
    }
    
    
    public class Marker
    {
        public int id {get; set;}
        public string name {get; set;}
        public string address {get; set;}
        public string type {get; set;}
    }
