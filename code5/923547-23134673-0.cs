    public class HttpCacheChangeMonitor : ChangeMonitor
	{
		private readonly string _uniqueId = Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture);
		private readonly string[] _httpCacheKeys;
		private readonly CacheItemPriority _priority = CacheItemPriority.Default;
		public override string UniqueId
		{
			get { return _uniqueId; }
		}
		public HttpCacheChangeMonitor(string httpCacheKey)
			: this(new[] { httpCacheKey }) { }
		public HttpCacheChangeMonitor(string[] httpCacheKeys) 
			: this(httpCacheKeys, System.Runtime.Caching.CacheItemPriority.Default) { }
		public HttpCacheChangeMonitor(string httpCacheKeys, System.Runtime.Caching.CacheItemPriority priority)
			: this (new []{httpCacheKeys}, priority){ }
		public HttpCacheChangeMonitor(string[] httpCacheKeys, System.Runtime.Caching.CacheItemPriority priority)
		{
			_httpCacheKeys = httpCacheKeys;
			if (priority == System.Runtime.Caching.CacheItemPriority.NotRemovable)
			{
				_priority = CacheItemPriority.NotRemovable;
			}
			Initialise();
		}
		private void Initialise()
		{
			HttpRuntime.Cache.Add(_uniqueId, _uniqueId, new CacheDependency(null, _httpCacheKeys), DateTime.MaxValue, Cache.NoSlidingExpiration, _priority, Callback);
			InitializationComplete();
		}
		private void Callback(string key, object value, CacheItemRemovedReason reason)
		{
			OnChanged(null);
		}
		protected override void Dispose(bool disposing)
		{
			Debug.WriteLine(
					_uniqueId + " notifying cache of change.", "HttpCacheChangeMonitor");
			HttpRuntime.Cache.Remove(_uniqueId);
		}
	}
