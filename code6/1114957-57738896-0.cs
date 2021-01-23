    app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
    {
        AuthenticationMode = AuthenticationMode.Active,
        AllowedAudiences = new[] { FirebaseValidAudience },
        Provider = new OAuthBearerAuthenticationProvider
        {
            OnValidateIdentity = OnValidateIdentity
        },
        TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKeys = issuerSigningKeys,
            ValidAudience = FirebaseValidAudience,
            ValidIssuer = FirebaseValidIssuer,
            IssuerSigningKeyResolver = (arbitrarily, declaring, these, parameters) => issuerSigningKeys
        }
    });        
