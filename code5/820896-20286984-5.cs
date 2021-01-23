    public class AuthenticatorImp : Google.Apis.Authentication.IAuthenticator
    {
        OAuth2Parameters parameters;
        public AuthenticatorImp(OAuth2Parameters parameters)
        {
            this.parameters = parameters;
        }
        /// <summary>
        /// Takes an existing httpwebrequest and modifies its headers according to 
        /// the authentication system used.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public void ApplyAuthenticationToRequest(HttpWebRequest request)
        {
            if (parameters.TokenType == "Bearer" && parameters.TokenExpiry < DateTime.Now)
            {
                OAuthUtil.RefreshAccessToken(parameters);
            }
            request.Headers.Add("Authorization: Bearer " + parameters.AccessToken);
        }
    }
