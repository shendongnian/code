    public class MyHeaderHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            string headerTokenValue;
            const string customHeaderKey = "My-Header";
            
            if (!request.Headers.TryGetValues(
                    customHeaderKey,
                    out headerTokenValue)
                || headerTokenValue.ToLower() != "true")
            {
                return base.SendAsync(request, cancellationToken);
            }
    
            return Task<HttpResponseMessage>.Factory.StartNew(
                () =>
                    {
                        var response = new HttpResponseMessage(
                            HttpStatusCode.Unauthorized);
                        var json = JsonConvert.SerializeObject(
                            new ErrorModel
                            {
                                Description = "error stuff",
                                Status = "Ooops"
                            });
                        response.Content = new StringContent(json);
                        // Ensure return type is JSON:
                        response.Content.Headers.ContentType =
                           new MediaTypeHeaderValue("application/json");
                        return response;    
                    });
        }
    }
