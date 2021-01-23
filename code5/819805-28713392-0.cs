    public void ConfigureAuth(IAppBuilder app)
    {
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new PathString("/Account/Login"),
            Provider = new CookieAuthenticationProvider()
            {
                OnApplyRedirect = ctx =>
                {
                    if (!IsApiRequest(ctx.Request))
                    {
                        ctx.Response.Redirect(ctx.RedirectUri);
                    }
                }
            }
        });
         
        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
    }
     
     
    private static bool IsApiRequest(IOwinRequest request)
    {
        string apiPath = VirtualPathUtility.ToAbsolute("~/api/");
        return request.Uri.LocalPath.StartsWith(apiPath);
    }
