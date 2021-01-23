    public class MapController
    {
        //here you make it "private" cause it doesn't need to be public anymore, 
        //you also don't new it up here, you are passing in a new on during construction.
        private Map map;
        public MapController(Map map)
        {
            this.map = map
        }
    
        // the rest of your code for this class...
