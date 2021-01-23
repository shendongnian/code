You could use the global cache object to hold user items instead of Session. With a sliding expiration equal to the Session.Timeout duration, it should act similar to Session.
		public void AddToCrossBrowserSession(string username, string key, object value)
		{
			string cacheKey = string.Format("Cross-browser-state:{0}/{1}", username, key);
			System.Web.HttpContext.Current.Cache.Add(cacheKey, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(Session.Timeout), System.Web.Caching.CacheItemPriority.Normal, null);
		}
		public object GetFromCrossBrowserSession(string username, string key)
		{
			string cacheKey = string.Format("Cross-browser-state:{0}/{1}", username, key);
			return System.Web.HttpContext.Current.Cache[cacheKey];
		}
