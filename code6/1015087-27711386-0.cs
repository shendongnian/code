    public partial class Startup
    {
      private void ConfigureAuth(IAppBuilder app)
      {
        var cookieOptions = new CookieAuthenticationOptions
          {
            LoginPath = new PathString("/Account/Login")
          };
     
        app.UseCookieAuthentication(cookieOptions);
      }
    }
