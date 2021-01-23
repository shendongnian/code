    public class WorkContext
    {
        private string _email;
        private Lazy<User> currentUser;
        private IAuthenticationService authService;
        private ICacheManager cacheManager;
       
        public User CurrentUser
        {
            get 
            { 
                var cachedUser = cacheManager.Get<User>(Constants.CacheUserKeyPrefix + this._email);
                if (cachedUser != null)
                {
                    return cachedUser;
                }
                else
                {
                    var user = currentUser.Value;
                    cacheManager.Set(Constants.CacheUserKeyPrefix + this._email, user, 30);
                    return user;
                }
            }
        }
        public WorkContext(string email)
        {
            Ensure.Argument.NotNullOrEmpty(email);
            this._email = email;
            this.authService = DependencyResolver.Current.GetService<IAuthenticationService>();
            this.cacheManager = DependencyResolver.Current.GetService<ICacheManager>();
            this.currentUser = new Lazy<User>(() => authService.GetUserByEmail(email));
        }
