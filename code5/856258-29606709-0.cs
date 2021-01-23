    public static void Configuration(IAppBuilder app)
    {
        UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new PathString(url.Action("LogOn", "Account", new { area = "Account" })),
            Provider = new CookieAuthenticationProvider
            {
                OnApplyRedirect = context => context.Response.Redirect(context.RedirectUri.Replace(CultureHelper.GetDefaultCulture(), Thread.CurrentUiCulture.Name))
            }
        });
    }
