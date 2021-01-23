    public class Startup {
      public void Configuration(IAppBuilder app) {
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
          AuthenticationType = "Cookies",
          LoginPath = new PathString("/Account/SignIn")
        });
    }
