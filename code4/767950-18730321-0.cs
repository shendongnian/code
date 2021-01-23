    public static class CacheHelper
    {
    	public static void WriteOutCacheHelper()
    	{
    		foreach (KeyValuePair<string, object> cache in Cache)
    		{
    			Console.WriteLine(cache.Key);
    		}
    	}
    	public static void WriteOutCacheHelper(string key)
    	{
    		Console.WriteLine(Get<object>(key).ToString());
    	}
    
    	public static bool Enabled { get; set; }
    
    	private static Dictionary<string, object> _cache;
    	public static Dictionary<string, object> Cache
    	{
    		get
    		{
    			if (_cache == null) _cache = new Dictionary<string, object>();
    			return _cache;
    		}
    	}
    
    	public static object lockObject = new object();
    	public static void Add<T>(T o, string key) 
    	{
    		if (!Enabled) return;
    
    		lock (lockObject)
    		{
    			if (Exists(key))
    				Cache[key] = o;
    			else
    				Cache.Add(key, o);
    		}
    	}
    
    	public static void Clear(string key)
    	{
    		if (!Enabled) return;
    
    		Cache.Remove(key);
    	}
    
    	public static bool Exists(string key)
    	{
    		if (!Enabled) return false;
    		return Cache.ContainsKey(key);
    	}
    
    	public static T Get<T>(string key) 
    	{
    		if (!Enabled) return default(T);
    
    		T value;
    		try
    		{
    			value = (!Exists(key) ? default(T) : (T) Cache[key]);
    		}
    		catch
    		{
    			value = default(T);
    		}
    
    		return value;
    	}
    
    	public static void ClearAll(bool force = false)
    	{
    		if (!force && !Enabled) return;
    		Cache.Clear();
    	}
    
    	public static List<T> GetStartingWith<T>(string cacheKey) where T : class
    	{
    		if (!Enabled) new List<T>();
    
    		return Cache.ToList().FindAll(f => f.Key.StartsWith(cacheKey, StringComparison.CurrentCultureIgnoreCase))
    			.Select(s => s.Value as T).ToList();
    	}
    }
