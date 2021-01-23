    var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
    var provider = new CookieAuthenticationProvider();
    var originalHandler = provider.OnApplyRedirect;
    provider.OnApplyRedirect = context =>
    {
    	if (!HttpContext.Current.Request.Url.AbsoluteUri.Contains("/api/"))
    	{
    		var routeValues = new RouteValueDictionary();
    		var uri = new Uri(context.RedirectUri);
    		var returnUrl = HttpUtility.ParseQueryString(uri.Query)[context.Options.ReturnUrlParameter];
    		routeValues.Add(context.Options.ReturnUrlParameter, returnUrl);
    		per.Action("login", "account", routeValues);
    		context.RedirectUri = newUri;
    		originalHandler.Invoke(context);
    	}
    };
        
    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
    	AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
    	LoginPath = new PathString(urlHelper.Action("Login", "Account")),
    	Provider = provider
    });
