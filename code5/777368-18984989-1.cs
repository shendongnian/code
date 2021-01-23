    public class Singleton
    {
         private Singleton(){}
         private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(()=>new Singleton());
    
        public static Singleton Instance{ get {return _instance.Value; } }
    }
