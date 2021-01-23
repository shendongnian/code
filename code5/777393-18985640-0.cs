    public abstract class FooBase
    {
        private readonly IDictionary<string,object> _readonlyCache;
    
        protected FooBase(IDictionary<string,object> cache)
        {
            _readonlyCache = cache;
        }
    }
