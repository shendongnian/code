    public class ResponseHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = base.SendAsync(request, cancellationToken);
            if (request.Method == HttpMethod.Post)
            {
                response.Result.StatusCode = response.Result.IsSuccessStatusCode ? System.Net.HttpStatusCode.OK : response.Result.StatusCode;
            }
            return response;
       }
    }
