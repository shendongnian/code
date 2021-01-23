    public LifetimeProxyMessageHandler : DelegatingHandler
    {
        private readonly IHttpMessageHandlerFactory factory;
        public LifetimeProxyMessageHandler(IHttpMessageHandlerFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException("factory");
            this.factory = factory;
        }
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpMessageHandler ephemeralHandler = factory.Create();
            return ephemeralHandler.SendAsync(request, cancellationToken);
        }
    }
