    public class MyObject
    {
        private string _name;
        // inline
        // private static List<Capture> _list = new List<Capture>();
        // if via static constructor
        private static List<Capture> _list;
    
        static MyObject() 
        {
            _list = new List<Capture>();
        }
    
        public MyObject(string name)
        {
            _name = name;
        }
    
        public void start()
        {
            _list.Add(this);
        }
    }
