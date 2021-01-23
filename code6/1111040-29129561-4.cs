	public class MyJsonServiceClientWithRetry : JsonServiceClient
	{
		public MyJsonServiceClientWithRetry()
		{
		}
		public MyJsonServiceClientWithRetry(int retryAttempts)
		{
			RetryAttempts = retryAttempts;
		}
		public MyJsonServiceClientWithRetry(string baseUri) : base(baseUri)
		{
		}
		public MyJsonServiceClientWithRetry(string syncReplyBaseUri, string asyncOneWayBaseUri) : base(syncReplyBaseUri, asyncOneWayBaseUri)
		{
		}
        // Retry attempts property
		public int RetryAttempts { get; set; }
		public override TResponse Send<TResponse> (string httpMethod, string relativeOrAbsoluteUrl, object request)
		{
			int attempts = RetryAttempts;
			while(true) 
			{
				attempts--;
				try {
					return base.Send<TResponse> (httpMethod, relativeOrAbsoluteUrl, request);
				} catch (WebServiceException webException) {
					// Throw the exception if the number of retries is 0 or we have made a bad request, or are unauthenticated
					if(attempts == 0 || webException.StatusCode == 400 || webException.StatusCode == 401)
						throw;
				} catch (Exception exception) {
					// Throw the exception if the number of retries is 0
					if(attempts == 0) 
						throw;
				}
			}
		}
	}
 
