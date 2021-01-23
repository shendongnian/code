    public class CustomMemoryCache : MemoryCache
		{
		public CustomMemoryCache(string name)
			: base(name)
			{
			}
		public override bool Add(string key, object value, DateTimeOffset absoluteExpiration, string regionName = null)
			{
			System.Web.Caching.OutputCache.Providers[System.Web.Caching.OutputCache.DefaultProviderName].Add(key, value, absoluteExpiration.DateTime);
			return true;
			}
		public override object Get(string key, string regionName = null)
			{
			return System.Web.Caching.OutputCache.Providers[System.Web.Caching.OutputCache.DefaultProviderName].Get(key);
			}
		}
