    class MainClass
    {
        // Define the list of map locations in the body of the class
        // It is private thus only available from within the class itself
        // Added underscore '_' to it that is quite common for private mmebers
        private List<MapLocation> _mapLocationList = new List<MapLocation>();
        public MainClass()
        {
            // Create an instance of the MapLocation, only valid within the constructor scope
            MapLocation item = new MapLocation();
            // Set the property of the instance
            item.Title = "Title";
            
            // Adds the MapLocation instance 'item' to the list of MapLocations
            _mapLocationList.Add(item);
        }
    }
