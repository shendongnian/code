    public class HttpRetryMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken) =>
            Policy
                .Handle<HttpRequestException>()
                .OrResult<HttpResponseMessage>(x => x.IsSuccessStatusCode)
                .WaitAndRetry(5, retryCount => TimeSpan.FromSeconds(Math.Pow(3, retryCount)))
                .ExecuteAsync(() => base.SendAsync(request, cancellationToken));
    }
    using (var client = new HttpClient(new HttpRetryMessageHandler(new HttpClientHandler())))
    {
        var result = await client.GetAsync("http://example.com");
    }
