        private UserManager<ApplicationUser> _userManager;
        public UserManager<ApplicationUser> UserManager {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUser>();
            }
            private set
            {
                _userManager = value;
            }
        }
