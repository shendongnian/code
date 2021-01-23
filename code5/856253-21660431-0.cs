    CookieAuthenticationProvider provider = new CookieAuthenticationProvider();
        
    var originalHandler = provider.OnApplyRedirect;
    provider.OnApplyRedirect = context =>
    {
        //insert your logic here to generate the redirection URI
        string NewURI = "....";
        //Overwrite the redirection uri
        context.RedirectUri = NewURI;
        originalHandler.Invoke(context);
    };
        
    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
       AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
       LoginPath = new PathString(url.Action("Login", "Account")),
       Provider = provider
    });
