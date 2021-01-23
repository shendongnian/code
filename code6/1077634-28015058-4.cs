    public class BypassCacheHttpRequestHandler : HttpClientHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Headers.IfModifiedSince == null)
                request.Headers.IfModifiedSince = new DateTimeOffset(DateTime.Now);
            return base.SendAsync(request, cancellationToken);
        }
    }
