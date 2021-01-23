        public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string publicClientId;
        private IKernel kernel;
        private readonly Logger logger;
        public ApplicationOAuthProvider(string publicClientId, IKernel kernel, Logger logger)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }
            if (kernel == null)
            {
                throw new ArgumentNullException("userManager");
            }
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            this.publicClientId = publicClientId;
            this.kernel = kernel;
            this.logger = logger;
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                var userManager = this.kernel.Get<UserManager<User, int>>();
                var user = await userManager.FindAsync(context.UserName, context.Password);
                if (user == null)
                {
                    this.logger.Info("Invalid grant for {0}", context.UserName);
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
                var oAuthIdentity =
                    await userManager.CreateIdentityAsync(user, context.Options.AuthenticationType);
                var cookiesIdentity =
                    await userManager.CreateIdentityAsync(user, CookieAuthenticationDefaults.AuthenticationType);
                var properties = CreateProperties(user.UserName);
                var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                context.Validated(ticket);
                context.Request.Context.Authentication.SignIn(cookiesIdentity);
                this.logger.Info("User '{0}' is signed in.", user.UserName);
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message, ex);
                throw;
            }
        }
