        var keySecret = authenticationConfiguration["JwtSigningKey"];
        var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keySecret));
        services.AddTransient(_ => new JwtSignInHandler(symmetricKey));
        services.AddAuthentication(options =>
        {
            // This causes the default authentication scheme to be JWT.
            // Without this, the Authorization header is not checked and
            // you'll get no results. However, this also means that if
            // you're already using cookies in your app, they won't be 
            // checked by default.
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters.ValidateIssuerSigningKey = true;
                options.TokenValidationParameters.IssuerSigningKey = symmetricKey;
                options.TokenValidationParameters.ValidAudience = JwtSignInHandler.TokenAudience;
                options.TokenValidationParameters.ValidIssuer = JwtSignInHandler.TokenIssuer;
            });
    I've seen other answers change other settings, such as `ClockSkew`; the defaults are set such that it should work for distributed environments whose clocks aren't exactly in sync. These are the only settings you need to change.
