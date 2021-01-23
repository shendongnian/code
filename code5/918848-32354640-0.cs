    public class OAuthBearerTokenAuthenticationProvider : OAuthBearerAuthenticationProvider
    {
        public override Task RequestToken(OAuthRequestTokenContext context)
        {
            var tokenCookie = context.OwinContext.Request.Cookies["BearerToken"];
            if (!String.IsNullOrEmpty(tokenCookie))
                context.Token = tokenCookie;
            return Task.FromResult<object>(null);
        }
    }
