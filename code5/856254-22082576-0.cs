    UrlHelper _url = new UrlHelper(HttpContext.Current.Request.RequestContext);
    public void ConfigureAuth(IAppBuilder app)
    {
       String actionUri = _url.Action("Login", "Account", new { });
       String unescapeActionUri = System.Uri.UnescapeDataString(actionUri);
       app.UseCookieAuthentication(new CookieAuthenticationOptions
       {
          AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
          LoginPath = new PathString(unescapeActionUri)
       });
    [...]
