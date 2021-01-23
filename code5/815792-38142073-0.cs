       public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                ...
                LoginPath = new PathString("/Account/Login"), // Remove this line
            });
