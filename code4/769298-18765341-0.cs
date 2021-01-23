    public sealed class SomeManager
    {
        private static readonly Lazy<SomeManager> lazy = 
            new Lazy<SomeManager>(() => new SomeManager());
        
        public static SomeManager Instance { get { return lazy.Value; } }
    
        private SomeManager()
        {
        }
    }
