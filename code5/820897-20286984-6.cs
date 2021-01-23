    public class ConfigurableHttpClientInitializer : IConfigurableHttpClientInitializer 
    {
        OAuth2Parameters parameters;
        public ConfigurableHttpClientInitializer(OAuth2Parameters parameters) {
            this.parameters = parameters;
        }
        /// <summary> Initializes an Http client after it was created. </summary>
        public void Initialize(ConfigurableHttpClient httpClient)
        {
            if (parameters.TokenType == "Bearer" && parameters.TokenExpiry < DateTime.Now)
            {
                OAuthUtil.RefreshAccessToken(parameters);
            }
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + parameters.AccessToken);
        }
    }
