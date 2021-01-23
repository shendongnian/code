    public class Service
    {
      public RouteLinksRepository RL;    // A collection of RouteLink types
      // ...
    }
    
    public class RouteLinksRepository
    {
        public List<RouteLink> RouteLinks;
        public bool AddRoute(RouteLink linkToAdd)
        {
            //Custom logic on whether or not to add link
        }
        //Your other logic for the class
    
    }
    
    public class RouteLink
    {
        public string FirstStopRef;
        public string LastStopRef;
        public Tracks RouteTrack;    // Another collection, this time of Track types
    }
