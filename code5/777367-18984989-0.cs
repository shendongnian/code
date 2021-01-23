    public class Singleton
    {
        private static Singleton _instance;
        private static object _lock = new object();
        private Singleton(){}
    
        public static Singleton Instance
        {
            get
            {
                if(_instance == null)
                {
                   lock(_lock)
                   {
                       if(_instance == null)
                           _instance = new Singleton();
                   }
                }
                return _instance;
            }
        }
    }
