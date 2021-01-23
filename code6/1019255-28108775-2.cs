    public class HmacAuthenticatingHandler : DelegatingHandler
    {
        public HmacAuthenticatingHandler(HttpMessageHandler innerHandler) 
           : base(innerHandler)
        {
        }
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // HACK: Set 'Content-Type' even for GET requests
            var invalidHeaders = (HashSet<string>)typeof(HttpHeaders)
                // use "_invalidHeaders" for System.Net.Http v2.2+
                .GetField("invalidHeaders", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(request.Headers);
            invalidHeaders.Remove("Content-Type");
            request.Headers.Remove("Content-Type");
            request.Headers.Add("Content-Type", "application/json");
            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
