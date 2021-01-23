    public ApplicationUserManager UserManager
    {
        get
        { 
            _userManager = new ApplicationUserManager(
                              new UserStore<ApplicationUser>(new ApplicationDbContext()));
            return _userManager ??
                   Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        private set
        {
            _userManager = value;
        }
    }
