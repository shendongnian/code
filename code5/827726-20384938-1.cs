    public class Singleton 
    {
        static readonly Singleton _instance = new Singleton();
    
        static Singleton() { }
    
        private Singleton() { }
    
        public static Singleton Instance
        {
            get  { return _instance; }
        }
    }
