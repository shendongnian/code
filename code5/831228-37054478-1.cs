    public class HeaderReaderHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Trace.TraceInformation("start HeaderReaderHandler");
            IEnumerable<string> headerValues;
            if (request.Headers.TryGetValues("x-client-id", out headerValues))
            {
                string token = headerValues.First();
                var requestScopedService = request.GetDependencyScope().GetService(typeof(IPerRequestScopedService)) as IPerRequestScopedService;
                requestScopedService.ClientId = token;
            }
            // Call the inner handler.
            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
