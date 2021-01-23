    public ApplicationUserManager UserManager
    {
       get
       {
          return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
       }
       private set
       {
          _userManager = value;
       }
    }
