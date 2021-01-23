    public static class CacheHelper<T>
    {
        public static T Get(string key, Func<T> function) {
            var obj = HttpContext.Current.Cache[key];
            if (obj == null)
            {
                obj = function.Invoke();
                HttpContext.Current.Cache.Add(key, obj, null, DateTime.Now.AddMinutes(3),
                    TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            return (T)obj;
        }
    }
