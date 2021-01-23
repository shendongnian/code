    public class CacheHandler
    {
        /// <summary>
        /// static cache dependencies
        /// </summary>
        readonly static CacheDependency dependecies = null;
        /// <summary>
        /// sliding expiration
        /// </summary>
        readonly static TimeSpan slidingExpiration = TimeSpan.FromMinutes(5);
    
        /// <summary>
        /// absolute expiration
        /// </summary>
        readonly static DateTime absoluteExpiration = System.Web.Caching.Cache.NoAbsoluteExpiration;
    
        /// <summary>
        /// private singleton 
        /// </summary>
        static CacheHandler handler;
    
        /// <summary>
        /// gets the current cache handler
        /// </summary>
        public static CacheHandler Current { get { return handler ?? (handler = new CacheHandler()); } }
    
        /// <summary>
        /// private constructor
        /// </summary>
        private CacheHandler() { }
    
        /// <summary>
        /// Gets \ Sets objects from the cache. Setting the object will use the default settings above
        /// </summary>
        /// <param name="key">the cache key</param>
        /// <returns>the object stored in the cache</returns>
        public object this[string key]
        {
            get
            {
                if (HttpContext.Current == null)
                    throw new Exception("The current HTTP context is unavailable. Unable to read cached objects.");
                return HttpContext.Current.Cache[key];
            }
            set
            {
                if (HttpContext.Current == null)
                    throw new Exception("The current HTTP context is unavailable. Unable to set the cache object.");
                HttpContext.Current.Cache.Insert(key, value, dependecies, absoluteExpiration , slidingExpiration);
            }
        }
    
        /// <summary>
        /// the current HTTP context
        /// </summary>
        public Cache Context
        {
            get
            {
                if (HttpContext.Current == null)
                    throw new Exception("The current HTTP context is unavailable. Unable to retrive the cache context.");
                return HttpContext.Current.Cache;
            }
        }
    }
