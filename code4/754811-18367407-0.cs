    [XmlRoot("locations")]
    public class BuildingList
    {
        public BuildingList() {Items = new List<Building>();}
        [XmlElement("location")]
        public List<Building> Items {get;set;}
    }
