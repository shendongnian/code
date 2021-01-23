	public class MemoryCacheDependencyTests
	{
		[Fact]
		public void CacheDependencyTest()
		{
			using (MemoryCache cache = new MemoryCache("TestCache", new NameValueCollection()))
			{
				cache.Add("HttpCacheTest1", DateTime.Now, new CacheItemPolicy {SlidingExpiration = new TimeSpan(0, 10, 0)});
				cache.Add("HttpCacheTest2", DateTime.Now, new CacheItemPolicy {SlidingExpiration = new TimeSpan(0, 10, 0)});
				
				// Add data to cache
				for (int idx = 0; idx < 10; idx++)
				{
					HttpRuntime.Cache.Add("Key" + idx, "Value" + idx, GetDependency(cache, idx), Cache.NoAbsoluteExpiration, new TimeSpan(0,10,0), CacheItemPriority.NotRemovable, null);
				}
				int middleCount = HttpRuntime.Cache.Count;
				// Flush cached items associated with "NamedData" change monitors
				cache.Remove("HttpCacheTest1");
				int finalCount = HttpRuntime.Cache.Count;
				Assert.Equal(10, middleCount);
				Assert.Equal(5, middleCount - finalCount);
			}
		}
		private static CacheDependency GetDependency(MemoryCache cache, int idx)
		{
			string name = (idx % 2 == 0) ? "HttpCacheTest1" : "HttpCacheTest2";
			return new MemoryCacheDependency(cache, name);
		}
	}
