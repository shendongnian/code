    public class Singleton
    {
        static readonly Lazy<Singleton> instance = 
            new Lazy<Singleton>(() => new Singleton());
        public static Singleton Instance
        {
            get { return instance; }
        }
    
        static Singleton() { }
        protected Singleton() { }
    }
