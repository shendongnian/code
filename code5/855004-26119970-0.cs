	public class NonCacheableTransformer : IBundleTransform
	{
		public void Process(BundleContext context, BundleResponse response)
		{
			context.UseServerCache = false;
			response.Cacheability = HttpCacheability.NoCache;
		}
	}
