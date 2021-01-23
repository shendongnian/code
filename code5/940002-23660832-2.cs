    public class LogRequestAndResponseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // log request body
            string requestBody = await request.Content.ReadAsStringAsync();
            Trace.WriteLine(requestBody);
            // let other handlers process the request
            var result = await base.SendAsync(request, cancellationToken);
            // once response body is ready, log it
            var responseBody = await result.Content.ReadAsStringAsync();
            Trace.WriteLine(responseBody);
            return result;
        }
    }
