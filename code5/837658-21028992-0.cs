    public class UserManager
    {
        public static bool IsLoggedIn(string username)
        {
            ObjectCache cache = MemoryCache.Default;
            return !string.IsNullOrEmpty(cache[username] as string);
        }
        public static void SetToLoggedIn(string username)
        {
            ObjectCache cache = MemoryCache.Default;
            CacheItemPolicy policy = new CacheItemPolicy();
            //Expires after 1 minute.
            policy.AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(1));
            cache.Set(username, username, policy);
        }
    }
