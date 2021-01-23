    public class MyCacheItem
		{
		public Object ItemData { get; set; }
		public DateTime UtcExpiry { get; set; }
		public DateTime UtcAdded { get; set; }
		}
	public class MyOutputCacheProvider: OutputCacheProvider
		{
		private readonly Dictionary<String, MyCacheItem> CacheDictionary = new Dictionary<String, MyCacheItem>(); 
		public override object Get(string key)
			{
			lock(CacheDictionary)
				{
				if (!CacheDictionary.ContainsKey(key))
					return null;
				var Item = CacheDictionary[key];
				// Item has expired?
				if (Item.UtcExpiry < DateTime.UtcNow)
					{
					Remove(key);
					return null;
					}
				return Item.ItemData;
				}
			}
		public override object Add(string key, object entry, DateTime utcExpiry)
			{
			lock (CacheDictionary)
				{
				if (!CacheDictionary.ContainsKey(key))
					{
					MyCacheItem CacheItem = new MyCacheItem
					    {
					        ItemData = entry, 
							UtcExpiry = utcExpiry,
							UtcAdded =  DateTime.UtcNow
					    };
					CacheDictionary.Add(key, CacheItem);
					return CacheItem.ItemData;
					}
					
				var Item = CacheDictionary[key];
				return Item.ItemData;
				}
			}
		public override void Set(string key, object entry, DateTime utcExpiry)
			{
			lock (CacheDictionary)
				{
				if (!CacheDictionary.ContainsKey(key))
					{
					Add(key, entry, utcExpiry);
					return;
					}
				
				CacheDictionary[key].ItemData = entry;
				CacheDictionary[key].UtcExpiry = utcExpiry;
				}
			}
		public override void Remove(string key)
			{
			lock (CacheDictionary)
				{
				if (!CacheDictionary.ContainsKey(key))
					return;
				CacheDictionary.Remove(key);
				}
			}
		}
