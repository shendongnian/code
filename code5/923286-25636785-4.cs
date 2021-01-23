    using System.Runtime.Caching;
    public int UsersOnlineCount
    {
        get
        {
            return MemoryCache.Default.Where(kv => kv.Value.ToString() == "User").Count();
        }
    }
