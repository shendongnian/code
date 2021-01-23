    public class HttpRetryMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken) =>
            Policy
                .Handle<HttpRequestException>()
                .OrResult<HttpResponseMessage>(
                    x => ((int)x.StatusCode >= 500) && ((int)x.StatusCode < 599))
                .WaitAndRetry(5, retryCount => TimeSpan.FromSeconds(Math.Pow(3, retryCount)))
                .ExecuteAsync(() => base.SendAsync(request, cancellationToken));
    }
