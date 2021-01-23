    app.UseCookieAuthentication(new CookieAuthenticationOptions()
                {
                    AuthenticationMode = AuthenticationMode.Passive,
                    AuthenticationType = DefaultAuthenticationTypes.ExternalCookie,
                    ExpireTimeSpan = TimeSpan.FromMinutes(30)
                });
