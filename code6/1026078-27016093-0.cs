    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        LoginPath = new PathString("/Account/Login"),
        Provider = new CookieAuthenticationProvider
        {
               OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UserManager, User>(
                validateInterval: TimeSpan.FromMinutes(1),
                regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager)),
       
               //**** This what I did ***//
                OnException = context => { }
        }
    });
