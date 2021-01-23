    var cao = new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider { OnApplyRedirect = ApplyRedirect }
            };
    app.UseCookieAuthentication(cao);
