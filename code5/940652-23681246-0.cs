    public class AuthorizationDelegatingHandler : DelegatingHandler
    {
        private const string API_KEY = "8139E7541722F5D91ED8FB15165F4"
        
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken)
        {
            if (request.Headers.Authorization == null)
                return request.CreateResponse(HttpStatusCode.Unauthorized);
            if (request.Headers.Authorization.Scheme != "Basic")
                return request.CreateResponse(HttpStatusCode.Unauthorized);
            var authToken = request.Headers.Authorization.Parameter;
            var apiKey = Encoding.UTF8.GetString(Convert.FromBase64String(authToken))
                .Split(':')
                .FirstOrDefault(x => !string.IsNullOrWhiteSpace(x));
            if (string.IsNullOrWhiteSpace(apiKey) || apiKey != API_KEY)
               return request.CreateResponse(HttpStatusCode.Unauthorized);
            return await base.SendAsync(request, cancellationToken);
        }
    }
