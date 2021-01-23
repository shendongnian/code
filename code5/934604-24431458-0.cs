    public class RootObject
    {
        private RootObject()
        {
        }
        private static RootObject _instance;
        public static RootObject Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RootObject();
                 }
                return _instance;
            }
        }
        public Form Form { get; set; }
    }
