    public abstract class Application : Controller
    {
        public UserType CurrentUserType
        {
            get
            {
                return currentUser.UserType;
            }
        }
        // singleton for current user
        
        protected User __currentUser = null;
        protected User currentUser
        {
            get
            {
                if (__currentUser == null && HttpContext != null && HttpContext.User.Identity.IsAuthenticated)
                {
                    // access to sql based on:
                    // HttpContext.User.Identity.IsAuthenticated
                    // HttpContext.User.Identity.Name
                    // etc
                }
                return __currentUser;
            }
        }
        
        // singleton for EF context
    
        private MyAppContext __context = null;
        protected MyAppContext context
        {
            get
            {
                if (__context == null)
                {
                    __context = new MyAppContext();
                }
                return __context;
            }
        }
    }
    
