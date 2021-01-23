	public class OrdersService : Service
	{
		public object Get(CachedOrders request)
		{
			var cacheKey = "unique_key_for_this_request";
			var isCached = false;
			var returnDto = base.RequestContext.ToOptimizedResultUsingCache(base.Cache,cacheKey,() => {
				isCached = true;             
			});
			// Do something if it was cached...
		}
	}
