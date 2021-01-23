    [Serializable, XmlRoot("locations")]
    public class BuildingList
    {
        [XmlArrayItem("location", typeof(Building))]
        public List<Building> locations { get; set; }
    }
    [Serializable]
    public class Building
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MUBuildingID { get; set; }
        public List<Building> GetAll()
        {
            ...
        }
    }
