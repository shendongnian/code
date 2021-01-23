    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        LoginPath = new PathString("/Account/LogOn"),
        Provider = new CookieAuthenticationProvider
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
    private bool IsApiRequest(IOwinRequest request)
    {
        return request.Uri.PathAndQuery.StartsWith("/api");
    }
