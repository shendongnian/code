    [XmlRoot("Unit")]
        public class AddPeopleCountRequest
        {
            [XmlAttribute("name")]
            public string Name { get; set; }
    
            [XmlAttribute("serialNumber")]
            public string SerialNumber { get; set; }
    
            [XmlAttribute("macAddress")]
            public string MacAddress { get; set; }
    
            [XmlElement(ElementName="Door", Type=typeof(Door))]
            public List<Door> Doors { get; set; }
        }
    
        
        public class Door 
        {
            [XmlAttribute("name")]
            public string Name { get; set; }
    
            [XmlAttribute("ID")]
            public int Id { get; set; }
    
            [XmlElement(ElementName = "count", Type = typeof(Count))]
            public List<Count> Counts { get; set; }
        }
    
        public class Count 
        {
            [XmlAttribute("date")]
            public DateTime Time { get; set; }
    
            [XmlAttribute("in")]
            public int In { get; set; }
    
            [XmlAttribute("out")]
            public int Out { get; set; }
        }
