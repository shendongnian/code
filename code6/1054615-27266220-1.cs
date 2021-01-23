    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class CrestCorsPolicyAttribute : Attribute, ICorsPolicyProvider 
    {
        private readonly CorsPolicy _policy;
        public CrestCorsPolicyAttribute()
        {
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true
            };
            var allowedOrigins = ConfigurationManager.AppSettings["AllowedOrigins"].Split(',');
            foreach (var allowedOrigin in allowedOrigins)
            {
                _policy.Origins.Add(allowedOrigin);
            }
        }
        public Task<CorsPolicy> GetCorsPolicyAsync
            (
            HttpRequestMessage request, 
            CancellationToken cancellationToken
            )
        {
            return Task.FromResult(_policy);
        }
    }
