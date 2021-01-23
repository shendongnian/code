    IOAuthCredentials credentials = new SessionStateCredentials();
    if (credentials.ConsumerKey == null || credentials.ConsumerSecret == null)
    {
        credentials.ConsumerKey = ConsumerKey;
        credentials.ConsumerSecret = ConsumerSecret;
    }
    auth = new WebAuthorizer
    {
        Credentials = credentials,
        PerformRedirect = authUrl => HttpContext.Current.Response.Redirect(authUrl)
    };
