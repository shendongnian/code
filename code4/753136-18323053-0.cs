    public class AuthMessageHandler : DelegatingHandler
    {
        protected ITokenProvider TokenProvider { get; private set; }
        protected IPrincipalProvider PrincipalProvider { get; private set; }
        public AuthMessageHandler(ITokenProvider tokenProvider, IPrincipalProvider principalProvider)
        {
            TokenProvider = tokenProvider;
            PrincipalProvider = principalProvider;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Identity identity = null;
            string token = ExtractToken(request);
            if (token != null && TokenProvider.Verify(token, out identity))
            {
                request.Properties.Add(Constants.IdentityKey, identity);
                var principal = PrincipalProvider.CreatePrincipal(identity);
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;
            }
            return base.SendAsync(request, cancellationToken);
        }
        private string ExtractToken(HttpRequestMessage request)
        {
            IEnumerable<string> tokenValues = null;
            if (request.Headers.TryGetValues(Constants.TokenHeaderKey, out tokenValues))
                return tokenValues.First();
            return null;
        }
    }
