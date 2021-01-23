    public class CustomTokenSecurityHandler : System.IdentityModel.Tokens.JwtSecurityTokenHandler
    {
        private const string KeyName = "http://somesite.com/url";
        private const string ValidIssuerString = "http://somesite.com/url";
        public override System.Collections.ObjectModel.ReadOnlyCollection<System.Security.Claims.ClaimsIdentity> ValidateToken(SecurityToken token)
        {
            var idConfig = System.IdentityModel.Configuration.SystemIdentityModelSection.Current.IdentityConfigurationElements.GetElement("");
             var validationParameters = new TokenValidationParameters()
            {
                ValidAudience = (idConfig.AudienceUris.Cast<AudienceUriElement>().First()).Value
            };
             // set up valid issuers
             if ((validationParameters.ValidIssuer == null) &&
                 (validationParameters.ValidIssuers == null || !validationParameters.ValidIssuers.Any()))
             {
                 validationParameters.ValidIssuers = new List<string> { ValidIssuerString };
             }
             // and signing token.
             if (validationParameters.IssuerSigningToken == null)
             {
                 var resolver = (NamedKeyIssuerTokenResolver)this.Configuration.IssuerTokenResolver;
                 if (resolver.SecurityKeys != null)
                 {
                     IList<SecurityKey> skeys;
                     if (resolver.SecurityKeys.TryGetValue(KeyName, out skeys))
                     {
                         var tok = new NamedKeySecurityToken(KeyName, "id", skeys);
                         validationParameters.IssuerSigningToken = tok;
                     }
                 }
             }
       
            var tokenString = (token as JwtSecurityToken);
             ClaimsPrincipal validated = base.ValidateToken(tokenString.RawData, validationParameters, out token);
             var result = new ReadOnlyCollection<ClaimsIdentity>(validated.Identities.ToList());
             return result;
        }
    }
