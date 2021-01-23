    public class MyHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("x-api-key", "1234567");
            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
