       REMOVE IF YOU HAVE IT IN YOUR CONTROLLER:
       public ApplicationUserManager UserManager
    {
        get
        {
            return _userManager ??    HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        private set
        {
            _userManager = value;
        }
    }
