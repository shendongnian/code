    public class Startup {
        public void Configuration(IAppBuilder app) {
            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationMode = AuthenticationMode.Active,
                LoginPath = new PathString("/account/login"),
                LogoutPath = new PathString("/account/logout"),
                Provider = new CookieAuthenticationProvider { OnApplyRedirect = ApplyRedirect },
            });
        }
    
        private static void ApplyRedirect(CookieApplyRedirectContext context) {
            if (context.Request.Path != context.Options.LogoutPath)
                context.RedirectUri = "http://accounts.domain.com/login?" +
                    new QueryString(
                        context.Options.ReturnUrlParameter,
                        context.Request.Uri.AbsoluteUri);
    
            context.Response.Redirect(context.RedirectUri);
        }
    }
