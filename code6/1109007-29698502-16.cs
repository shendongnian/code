        RsaSecurityKey key;
        using (var textReader = new System.IO.StreamReader(stream))
        {
            RSACryptoServiceProvider publicAndPrivate = new RSACryptoServiceProvider();
            publicAndPrivate.FromXmlString(textReader.ReadToEnd());
            key = new RsaSecurityKey(publicAndPrivate.ExportParameters(true));
        }
        services.AddInstance(new SigningCredentials(key, SecurityAlgorithms.RsaSha256Signature, SecurityAlgorithms.Sha256Digest));
        services.Configure<OAuthBearerAuthenticationOptions>(bearer =>
        {
            bearer.TokenValidationParameters.IssuerSigningKey = key;
            bearer.TokenValidationParameters.ValidAudience = TokenAudience;
            bearer.TokenValidationParameters.ValidIssuer = TokenIssuer;
        });
