    public class Alpha
    {
        // property to access member variable from outside
        public Beta beta{ get; private set; }
        public Alpha()
        {
             // initialize the member with a new instance
             beta = new Beta();
        }
        public class Beta
        {
        }
    }
