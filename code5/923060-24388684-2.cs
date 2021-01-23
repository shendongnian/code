	public class StaHandler : DelegatingHandler
	{
		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			// consider moving it to singleton instance to improve performance
			var staTaskScheduler = new StaTaskScheduler(100);
			return Task.Factory.StartNew<HttpResponseMessage>(() =>
			{
				//somethign that does its magic and returns a HttpResponseMessag
				return new HttpResponseMessage();
			}, cancellationToken,
				TaskCreationOptions.None,
				staTaskScheduler);
		}
	}
