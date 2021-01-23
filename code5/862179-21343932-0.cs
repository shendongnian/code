    static Startup()
    {
        PublicClientId = "self";
        // The UserStore class exposes a *very basic* user management api.
        // In the following code, we configure it to store user data
        // as type IdentityUser in the MyDbContext data store.             
        var userStore = new UserStore<IdentityUser>(new MyDbContext());            
        // The UserManager class exposes a higher level user management api, 
        // that automatically saves changes to the UserStore. 
        // In the following code, we configure it to use the UserStore that we just created.            
        var userManager = new UserManager<IdentityUser>(userStore);
        // The UserManagerFactory implement the factory pattern
        // in order to get one instance of UserManager per request for the application.
        UserManagerFactory = () => userManager;
        OAuthOptions = new OAuthAuthorizationServerOptions
        {
            TokenEndpointPath = new PathString("/Token"),
            Provider = new ApplicationOAuthProvider(PublicClientId, UserManagerFactory),
            AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
            AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
            AllowInsecureHttp = true
        };
    }
