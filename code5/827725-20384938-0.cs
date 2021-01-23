    public class Singleton 
    {
        static readonly Singleton _instance = new Singleton();
    
        static Singleton() { }
    
        private Singleton() { }
    
        static public Singleton Instance
        {
            get  { return _instance; }
        }
    }
