    private static UserManager<ApplicationUser> UserManager
    {
        get { return new UserManager<ApplicationUser>(
              new UserStore<ApplicationUser>(new ApplicationDbContext())); }
    }
    public static ApplicationUser GetUser(string id)
    {
        using (var userManager = UserManager)
        {
            return UserManager.FindById(id);
        }
    }
