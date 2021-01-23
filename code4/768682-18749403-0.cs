    public class MyObject
    {
        private string _name;
        private static List<Capture> _list = new List<Capture>();
    
        public MyObject(string name)
        {
            _name = name;
        }
    
        public void start()
        {
            _list.Add(this);
        }
    }
