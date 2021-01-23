    public void ConfigureOAuth(IAppBuilder app)
    {
        var issuer = "<the_same_issuer_as_AuthenticationServer.Api>";
        // Api controllers with an [Authorize] attribute will be validated with JWT
        Func<IEnumerable<Audience>> allowedAudiences = () => DatabaseAccessLayer.GetAllowedAudiences();
        var bearerOptions = new OAuthBearerAuthenticationOptions
        {
            AccessTokenFormat = new JwtFormat(new TokenValidationParameters
            {
                AudienceValidator = (audiences, securityToken, validationParameters) =>
                {
                    return allowedAudiences().Select(x => x.ClientId).Intersect(audiences).Count() > 0;
                },
                ValidIssuers = new ValidIssuers { Audiences = allowedAudiences },
                IssuerSigningTokens = new SecurityTokensTokens(issuer) { Audiences = allowedAudiences }
            })
        };
        app.UseOAuthBearerAuthentication(bearerOptions);
    }
    public abstract class AbstractAudiences<T> : IEnumerable<T>
    {
        public Func<IEnumerable<Audience>> Audiences { get; set; }
        public abstract IEnumerator<T> GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    public class SecurityTokensTokens : AbstractAudiences<SecurityToken>
    {
        private string issuer;
        public SecurityTokensTokens(string issuer)
        {
            this.issuer = issuer;
        }
        public override IEnumerator<SecurityToken> GetEnumerator()
        {
            foreach (var aud in Audiences())
            {
                foreach (var securityToken in new SymmetricKeyIssuerSecurityTokenProvider(issuer, TextEncodings.Base64Url.Decode(aud.ClientSecret)).SecurityTokens)
                {
                    yield return securityToken;
                };
            }
        }
    }
    public class ValidIssuers : AbstractAudiences<string>
    {
        public override IEnumerator<string> GetEnumerator()
        {
            foreach (var aud in Audiences())
            {
                yield return aud.ClientSecret;
            }
        }
    }
}
