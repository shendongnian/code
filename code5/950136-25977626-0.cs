    //public AccountController()
            //    : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SharedContext())))
            //{
    
            //}
    
            public AccountController(UserManager<ApplicationUser> userManager, UserStore<ApplicationUser> userStore)
            {
                _userStore = userStore;
                _userManager = userManager;
            }
    
            private UserManager<ApplicationUser> _userManager { get; set; }
            private UserStore<ApplicationUser> _userStore { get; set; }
    
