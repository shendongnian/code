    const string XmlSchemaString = "http://www.w3.org/2001/XMLSchema#string";
    ...
    var googlePlusOptions = new GoogleOAuth2AuthenticationOptions
    {
        ClientId = "yourclientid",
        ClientSecret = "yourclientsecret",
        Provider = new GoogleOAuth2AuthenticationProvider
        {
            OnAuthenticated = (context) =>
            {
                context.Identity.AddClaim(new System.Security.Claims.Claim("urn:googleplus:access_token", context.AccessToken, XmlSchemaString, "Google"));
                return Task.FromResult(0);
            }
        }
    };
    app.UseGoogleAuthentication(googlePlusOptions);
