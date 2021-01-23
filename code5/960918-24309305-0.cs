        public class MapLocationList
        {
            public string name { get; set; }
            public List<MapLocationListItem> listItems { get; set; }
            public MapLocationList()
            {
                listItems = new List<MapLocationListItem>();
            }
            public MapLocationListItem findByName(string locationName)
            {
                MapLocationListItem findRes = listItems.Where(x => x.name.Equals(locationName)).FirstOrDefault();
                return findRes;
            }
        }
        public class MapLocationListItem
        {
            public string name { get; set; }
            public string type { get; set; }
            public string heading { get; set; }
            public string subheading { get; set; }
            MapLocationList list { get; set; }
        }
