	public class CachedResult : IHttpActionResult
	{
		private readonly IHttpActionResult _decorated;
		private readonly TimeSpan _maxAge;
		public CachedResult(IHttpActionResult decorated, TimeSpan maxAge)
		{
			_decorated = decorated;
			_maxAge = maxAge;
		}
		public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
		{
			var response = await _decorated.ExecuteAsync(cancellationToken);
			response.Headers.CacheControl = new CacheControlHeaderValue
			{
				Public = true,
				MaxAge = _maxAge
			};
			return response;
		}
	}
