    public class CustomDelegatingHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Task<HttpResponseMessage> response = base.SendAsync(request, cancellationToken);
            if (response.Result.StatusCode == HttpStatusCode.NotFound)
            {
                response.Result.Content = new StringContent(File.ReadAllText(@"index.html"));
                response.Result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
                response.Result.StatusCode = HttpStatusCode.OK;
            }
            return response;
        }
    }
