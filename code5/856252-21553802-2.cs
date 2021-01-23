    public void ConfigureAuth(IAppBuilder app)
    {
        UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
        CookieAuthenticationProvider provider = new CookieAuthenticationProvider();
        var originalHandler = provider.OnApplyRedirect;
        //Our logic to dynamically modify the path (maybe needs some fine tuning)
        provider.OnApplyRedirect = context =>
        {
            var mvcContext = new HttpContextWrapper(HttpContext.Current);
            var routeData = RouteTable.Routes.GetRouteData(mvcContext);
            //Get the current language  
            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("lang", routeData.Values["lang"]);
            
            //Reuse the RetrunUrl
            Uri uri = new Uri(context.RedirectUri);
            string returnUrl = HttpUtility.ParseQueryString(uri.Query)[context.Options.ReturnUrlParameter];
            routeValues.Add(context.Options.ReturnUrlParameter, returnUrl);
            //Overwrite the redirection uri
            context.RedirectUri = url.Action("login", "account", routeValues);
            originalHandler.Invoke(context);
        };
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new PathString(url.Action("login", "account")),
            //Set the Provider
            Provider = provider
        });
    }
