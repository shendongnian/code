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
            Uri absoluteUri;
            if (Uri.TryCreate(context.RedirectUri, UriKind.Absolute, out absoluteUri)) {
                var path = PathString.FromUriComponent(absoluteUri);
                if (String.Equals(path.Value, context.OwinContext.Request.PathBase +
                    context.Options.LoginPath.Value, StringComparison.OrdinalIgnoreCase))
                    context.RedirectUri = "http://accounts.domain.com/login" +
                        new QueryString(
                            context.Options.ReturnUrlParameter,
                            context.Request.Uri.AbsoluteUri);
            }
    
            context.Response.Redirect(context.RedirectUri);
        }
    }
