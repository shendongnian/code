    public class HttpRetryHandler : DelegatingHandler
    {
        private int MaxRetries;
        private int WaitTime;
        public HttpRetryHandler(HttpMessageHandler innerHandler, int maxRetries = 3, int waitSeconds = 0)
            : base(innerHandler)
        {
            MaxRetries = maxRetries;
            WaitTime = waitSeconds * 1000; 
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;
            for (int i = 0; i < MaxRetries; i++)
            {
                try
                {
                    response = await base.SendAsync(request, cancellationToken);
                    if (response.IsSuccessStatusCode)
                    {
                        return response;
                    }
                    else if(response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        // Don't reattempt a bad request
                        break; 
                    }
                }
                catch
                {
                    // Ignore Error As We Will Attempt Again
                }
                finally
                {
                    response.Dispose(); 
                }
                if(WaitTime > 0)
                {
                    await Task.Delay(WaitTime);
                }
            }
            return response;
        }
    }
}
