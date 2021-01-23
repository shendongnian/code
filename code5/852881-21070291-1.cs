    public class Restaurant
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "location")]
        public string Location { get; set; }
    }
    public class Restaurants
    {
        [XmlElement(ElementName="Restaurant")]
        public List<Restaurant> Items { get; set; }
    }
