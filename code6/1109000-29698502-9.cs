    using (var stream = typeof(Startup).GetTypeInfo().Assembly.GetManifestResourceStream("MyNamespace.bearer.xml"))
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
        bearer.TokenValidationParameters.ValidAudience = "Myself";
        bearer.TokenValidationParameters.ValidIssuer = "Myself";
    });
