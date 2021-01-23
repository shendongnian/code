    public class ApiAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private Func<IUserService> userServiceFactory;
        public ApiAuthorizationServerProvider(Func<IUserService> userServiceFactory)
        {
            this.userServiceFactory = userServiceFactory;
        }
        // other code deleted for brevity...
        private IUserService userService 
        { 
            get
            {
                return this.userServiceFactory.Invoke();
            }
        }
        public override async Task GrantResourceOwnerCredentials(
            OAuthGrantResourceOwnerCredentialsContext context)
        {
            // other code deleted for brevity...
            // Just use the service like this
            User user = this.userService.Query(e => e.Email.Equals(context.UserName) &&
                e.Password.Equals(context.Password)).FirstOrDefault();
            // other code deleted for brevity...
        }
    }
