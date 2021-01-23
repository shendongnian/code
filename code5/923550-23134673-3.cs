    public class HttpCacheChangeMonitorTests
	{
		[Fact]
		public void ChangeMonitorTest()
		{
			HttpRuntime.Cache.Add("ChangeMonitorTest1", "", null, Cache.NoAbsoluteExpiration, new TimeSpan(0,10,0), CacheItemPriority.Normal, null);
			HttpRuntime.Cache.Add("ChangeMonitorTest2", "", null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0), CacheItemPriority.Normal, null);
			using (MemoryCache cache = new MemoryCache("TestCache", new NameValueCollection()))
			{
				// Add data to cache
				for (int idx = 0; idx < 10; idx++)
				{
					cache.Add("Key" + idx, "Value" + idx, GetPolicy(idx));
				}
				long middleCount = cache.GetCount();
				// Flush cached items associated with "NamedData" change monitors
				HttpRuntime.Cache.Remove("ChangeMonitorTest1");
				long finalCount = cache.GetCount();
				Assert.Equal(10, middleCount);
				Assert.Equal(5, middleCount - finalCount);
				HttpRuntime.Cache.Remove("ChangeMonitorTest2");
			}
		}
		private static CacheItemPolicy GetPolicy(int idx)
		{
			string name = (idx % 2 == 0) ? "ChangeMonitorTest1" : "ChangeMonitorTest2";
			CacheItemPolicy cip = new CacheItemPolicy();
			cip.AbsoluteExpiration = System.DateTimeOffset.UtcNow.AddHours(1);
			cip.ChangeMonitors.Add(new HttpCacheChangeMonitor(name));
			return cip;
		}
	}
