    app.UseJwtBearerAuthentication(options =>
    {
        // Basic settings - signing key to validate with, audience and issuer.
        options.TokenValidationParameters.IssuerSigningKey = key;
        options.TokenValidationParameters.ValidAudience = tokenOptions.Audience;
        options.TokenValidationParameters.ValidIssuer = tokenOptions.Issuer;
        // When receiving a token, check that we've signed it.
        options.TokenValidationParameters.ValidateSignature = true;
        // When receiving a token, check that it is still valid.
        options.TokenValidationParameters.ValidateLifetime = true;
        // This defines the maximum allowable clock skew - i.e. provides a tolerance on the 
        // token expiry time when validating the lifetime. As we're creating the tokens locally
        // and validating them on the same machines which should have synchronised 
        // time, this can be set to zero. Where external tokens are used, some leeway here 
        // could be useful.
        options.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
    });
