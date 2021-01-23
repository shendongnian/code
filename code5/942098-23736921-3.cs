    public class MvcPostAuthenticateRequestProvider : IPostAuthenticateRequestProvider
    {
        private readonly IApplicationConfiguration configuration;
        public MvcPostAuthenticateRequestProvider(IApplicationConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ApplyPrincipleToCurrentRequest()
        {
            // ...
        }
    }
