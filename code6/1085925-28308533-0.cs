    public static class CacheHelper<T>
    {
        public static T Get(string key, Func<T> function) {
            var obj = HttpContext.Current.Cache[key]; // removed the cast
            if (obj == null)
            {
                obj = function.Invoke();
                if (obj == null)
                {
                    return default(T);
                }
                HttpContext.Current.Cache.Add(key, obj, null, DateTime.Now.AddMinutes(3), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            
            return (T)obj; // now obj won't be null, but it might still be a different type
        }
    }
