    public class CacheOfExamples
    {
        public CacheOfExamples()
        {
            var settings = new NameValueCollection();
            settings.Add("PhysicalMemoryLimitPercentage", "75");
    
            _cache = new MemoryCache("CacheOfExamples", settings);
        }
    
        private MemoryCache _cache;
    
        public ExampleClass GetData(string key)
        {
            var record = _cache.Get(key) as ExampleClass;
        
            //If record was null that means the item was not in the cache.
            if(record == null)
            {
                record = new ExampleClass();
                _cache.Add(key, record, expiresetting, null);
            }
            return record;
        }
    }
