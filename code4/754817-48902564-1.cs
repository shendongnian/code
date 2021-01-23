    [XmlRoot("locations")]
    public class BuildingList
    {
        public BuildingList()
        {
            Items = new List();
        }
        [XmlArray("locations")]
        [XmlArrayItem("location", typeof(Building))]
        public List Items;
    }
