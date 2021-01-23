    public interface IHappyCache
    {
        object Add(string key, object value, CacheDependency dependencies, 
            DateTime absoluteExpiration, TimeSpan slidingExpiration, 
            CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback);
    
        object this[string key] { get; set; }
    }
    
    public class HappyCache : IHappyCache
    {
        public object Add(string key, object value, CacheDependency dependencies, 
            DateTime absoluteExpiration, TimeSpan slidingExpiration, 
            CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback)
        {
            //wrapper to whatever caching mechanism you want to use
            return new object();
        }
    
        public object this[string key]
        {
            get
            {
                //wrapper to whatever caching mechanism you want to use
                return new object();
            }
            set
            {
                //wrapper to whatever caching mechanism you want to use
            }
        }
    }
