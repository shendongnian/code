    private readonly IOwinContext _iOwinContext = HttpContext.Current.GetOwinContext();
    public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? _iOwinContext.Get<ApplicationUserManager>() ;
            }
            private set
            {
                _userManager = value;
            }
        }
