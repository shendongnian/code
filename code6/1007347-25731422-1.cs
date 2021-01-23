    public static UserManager<User,int> Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
    {
        var manager = new UserManager<User,int>(new UserStore<User,int>(new ApplicationDbContext()))
        {
            ClaimsIdentityFactory = new AppClaimsIdentityFactory()
        };
        // more initialization here
        return manager;
    }
