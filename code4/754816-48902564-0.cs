    [XmlRoot("locations")]
    public class BuildingList
    {
        [XmlArrayItem("location", typeof(Building))]
        public List<Building> Items {get;set;}
    }
