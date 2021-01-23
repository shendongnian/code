    public partial class Startup
    {
    private static bool IsAjaxRequest(IOwinRequest request)
    {
        IReadableStringCollection query = request.Query;
        if ((query != null) && (query["X-Requested-With"] == "XMLHttpRequest"))
        {
            return true;
        }
        IHeaderDictionary headers = request.Headers;
        return ((headers != null) && (headers["X-Requested-With"] == "XMLHttpRequest"));
    }
 
    // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
    public void ConfigureAuth(IAppBuilder app)
    {
        // Enable the application to use a cookie to store information for the signed in user
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new PathString("/Account/Login"),
            Provider = new CookieAuthenticationProvider
            {
                OnApplyRedirect = ctx =>
                {
                    if (!IsAjaxRequest(ctx.Request))
                    {
                        ctx.Response.Redirect(ctx.RedirectUri);
                    }
                }
            }
        });
        // Use a cookie to temporarily store information about a user logging in with a third party login provider
        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
 
    }
}
