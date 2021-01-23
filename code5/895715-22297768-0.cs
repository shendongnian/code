    public class Service
    {
      private List<RouteLink> RL;    // A collection of RouteLink types
      ...
    }
    
    public class RouteLink
    {
        public string FirstStopRef;
        public string LastStopRef;
        private List<Track> Tracks;    // Another collection, this time of Track types
    }
  
