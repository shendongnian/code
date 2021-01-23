    public AccountController()
    : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MyDbContext())))
    {
    }
    public AccountController(UserManager<ApplicationUser> userManager)
    {
        UserManager = userManager;
    }
    public UserManager<ApplicationUser> UserManager { get; private set; }
