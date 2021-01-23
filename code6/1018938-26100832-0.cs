    public sealed class Singleton
    {
        private static Singleton instance=null;
    
        private Singleton()
        {
        }
    
        public static Singleton Instance
        {
            get
            {
                instance = new Singleton();
                return instance;
            }
        }
    }
