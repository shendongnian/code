	public class OrdersService : Service
	{
		public object Get(CachedOrders request)
		{
			var cacheKey = "unique_key_for_this_request";
			var returnDto = base.RequestContext.ToOptimizedResultUsingCache(base.Cache,cacheKey,() => {
				return new MyReturnDto {
					CachedAt = DateTime.Now()
				};                
			});
		}
	}
