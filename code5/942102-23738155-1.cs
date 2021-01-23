    /// <summary>
    /// Provides PostAuthenticateRequest functionality
    /// </summary>
    public class MvcPostAuthenticateRequestProvider : IPostAuthenticateRequestProvider
    {
        #region Declarations
        private readonly IApplicationConfiguration _configuration;
        
        #endregion
        #region Constructors
        public MvcPostAuthenticateRequestProvider(IApplicationConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        #endregion
        #region IPostAuthenticateRequestProvider Members
        /// <summary>
        /// Applies a correctly setup principle to the Http request
        /// </summary>
        /// <param name="httpContext"></param>
        public void ApplyPrincipleToHttpRequest(HttpContext httpContext)
        {
            // declare a collection to hold roles for the current user
            String[] roles;
            // Get the current identity
            var identity = HttpContext.Current.User.Identity;
            // Check if the request is authenticated...
            if (httpContext.Request.IsAuthenticated)
            {
                // ...it is so load the roles collection for the user
                roles = Roles.GetRolesForUser(identity.Name);
            }
            else
            { 
                // ...it isn't so load the collection with the unknown role
                roles = new[] { _configuration.UnknownUserRoleName };
            }
            // Create a new WebIdenty from the current identity 
            // and using the roles collection just populated
            var webIdentity = new WebIdentity(identity, roles);
            // Create a principal using the web identity and load it
            // with the app configuration
            var principal = new WebsitePrincipal(webIdentity)
            {
                ApplicationConfiguration = _configuration
            };
            // Set the user for the specified Http context
            httpContext.User = principal;
        }
        #endregion
    }
