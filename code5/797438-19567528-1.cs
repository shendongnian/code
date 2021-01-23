    public AccountController() : this(Startup.UserManagerFactory())
    {
    }
    public AccountController(UserManager<IdentityUser> userManager)
    {
        UserManager = userManager;
    }
    public UserManager<IdentityUser> UserManager { get; private set; }
