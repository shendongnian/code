    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IAntiforgery antiforgery)
    {
       app.UseCookieAuthentication(new CookieAuthenticationOptions()
        {
            AuthenticationScheme = "__auth__",
            LoginPath = "/account/login",
            AccessDeniedPath = "/account/forbidden",
            AutomaticAuthenticate = true,
            AutomaticChallenge = false  //<@@@@@@@
        });
    }
