    public AccountController() : this(null)
    {
    }
    public AccountController(UserManager<User> userManager = null)
    {
        DBContext = new MyDBContext();
        if (userManager == null)
            userManager = new UserManager<User>(new UserStore<User>(DBContext));
        UserManager = userManager;
    }
    public UserManager<User> UserManager { get; private set; }
    public MyDBContext DBContext;
