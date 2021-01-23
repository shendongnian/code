    class MapLocation
    {
        // constructor
        public MapLocation()
        {
            MapLocationList = new List<MapLocation>();
            MapLocation MapLocationItem = new MapLocation();
            MapLocationItem.Title = "Title";
            MapLocationList.Add(MapLocationItem);
        }
        // collection initializer
        private List<MapLocation> MapLocationList = new List<MapLocation>()
        {
              // object initializer
              new MapLocation
              {
                Title = "Title"
              }
        };
        
        public string Title{get;set;}
    }
