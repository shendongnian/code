    public class HttpCacheChangeMonitor
	{
		[Fact]
		public void ChangeMonitorTest()
		{
			HttpRuntime.Cache.Add("ChangeMonitorTest", "", null, Cache.NoAbsoluteExpiration, new TimeSpan(0,10,0), CacheItemPriority.Normal, null);
			HttpRuntime.Cache.Add("NotTest", "", null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0), CacheItemPriority.Normal, null);
			using (MemoryCache cache = new MemoryCache("TestCache", new NameValueCollection()))
			{
				// Add data to cache
				for (int idx = 0; idx < 10; idx++)
				{
					cache.Add("Key" + idx, "Value" + idx, GetPolicy(idx));
				}
				long middleCount = cache.GetCount();
				// Flush cached items associated with "NamedData" change monitors
				HttpRuntime.Cache.Remove("ChangeMonitorTest");
				long finalCount = cache.GetCount();
				Assert.Equal(10, middleCount);
				Assert.Equal(5, middleCount - finalCount);
			}
		}
		private static CacheItemPolicy GetPolicy(int idx)
		{
			string name = (idx % 2 == 0) ? "NotTest" : "ChangeMonitorTest";
			CacheItemPolicy cip = new CacheItemPolicy();
			cip.AbsoluteExpiration = System.DateTimeOffset.UtcNow.AddHours(1);
			cip.ChangeMonitors.Add(new HttpCacheChangeMonitor(name));
			return cip;
		}
	}
