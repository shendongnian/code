    class ShopifyAuthenticator : OAuth2Authenticator
    {
        public ShopifyAuthenticator(string accessToken)
            : base(accessToken)
        {
    
        }
    
        public override void Authenticate(IRestClient client, IRestRequest request)
        {
            // only add the Authorization parameter if it hasn't been added.
            if (!request.Parameters.Any(p => p.Name.Equals("X-Shopify-Access-Token", StringComparison.OrdinalIgnoreCase)))
            {
                request.AddParameter("X-Shopify-Access-Token", AccessToken, ParameterType.HttpHeader);
            }
        }
    }
