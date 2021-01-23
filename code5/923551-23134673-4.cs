	public class MemoryCacheDependency : CacheDependency
	{
		private readonly string _uniqueId = Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture);
		private readonly IEnumerable<string> _cacheKeys;
		private readonly MemoryCache _cache;
		public override string GetUniqueID()
		{
			return _uniqueId;
		}
		public MemoryCacheDependency(MemoryCache cache, string cacheKey)
			: this(cache, new[] { cacheKey }) { }
		public MemoryCacheDependency(MemoryCache cache, IEnumerable<string> cacheKeys)
		{
			_cache = cache;
			_cacheKeys = cacheKeys;
			Initialise();
		}
		private void Initialise()
		{
			var monitor = _cache.CreateCacheEntryChangeMonitor(_cacheKeys);
			CacheItemPolicy pol = new CacheItemPolicy{AbsoluteExpiration = DateTime.MaxValue, Priority = CacheItemPriority.NotRemovable};
			pol.ChangeMonitors.Add(monitor);
			pol.RemovedCallback = Callback;
			_cache.Add(_uniqueId, _uniqueId, pol);
			FinishInit();
		}
		private void Callback(CacheEntryRemovedArguments arguments)
		{
			NotifyDependencyChanged(arguments.Source, EventArgs.Empty);
		}
		protected override void DependencyDispose()
		{
			Debug.WriteLine(
					   _uniqueId + " notifying cache of change.", "ObjectCacheDependency");
			_cache.Remove(_uniqueId);
			base.DependencyDispose();
		}
	}
