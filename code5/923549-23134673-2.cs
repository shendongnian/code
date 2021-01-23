    public class HttpCacheChangeMonitor : ChangeMonitor
	{
		private readonly string _uniqueId = Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture);
		private readonly string[] _httpCacheKeys;
		
		public override string UniqueId
		{
			get { return _uniqueId; }
		}
		public HttpCacheChangeMonitor(string httpCacheKey)
			: this(new[] { httpCacheKey }) { }
		public HttpCacheChangeMonitor(string[] httpCacheKeys)
		{
			_httpCacheKeys = httpCacheKeys;
			Initialise();
		}
		private void Initialise()
		{
			HttpRuntime.Cache.Add(_uniqueId, _uniqueId, new CacheDependency(null, _httpCacheKeys), DateTime.MaxValue, Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, Callback);
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
