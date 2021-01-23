    [Serializable()]
    [XmlRoot("locations")]
    public class LocationCollection{
    	[XmlElement("location")]
    	public Location[] Locations {get;set;}
    }
    
    [Serializable()]
    [XmlRoot("location")]
    public class Location
    {    
        [XmlElement("id")]
        public int LocationID { get; set; }
    	[XmlAttribute("locationtype")]
    	public string LocationType {get;set;}
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("mubuildingid")]
        public string MUBuildingID { get; set; }    
    }
