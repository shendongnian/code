    public class CorsPolicyProvider : Attribute, ICorsPolicyProvider
    {
        private CorsPolicy _policy;
        public CorsPolicyProvider()
        {
            // Create a CORS policy.
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true,
                AllowAnyOrigin = true
            };
           // Magic line right here
            _policy.Origins.Add("*");
        }
        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
