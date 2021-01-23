    //NOTE: property, root class names is different. 
    //So you can name it what you want but you need to specify xml tag name in attribute
    [XmlRoot("vehicle")]
    public class vehicleObject
    {
        public string make { get; set; }
        public string color { get; set; }
        [System.Xml.Serialization.XmlElement("owner")]
        public List<vehicleOwner> ownerList { get; set; }
    }
   
    public class vehicleOwner
    {
        public int id { get; set; }
        
        [System.Xml.Serialization.XmlElement("name")]
        public string nameField { get; set; }
    } 
