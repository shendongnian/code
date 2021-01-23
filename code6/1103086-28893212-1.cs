    public class Impersonate : IDisposable
    {
        private UserManager<ApplicationUser> userManager;
        public Impersonate(UserManager<ApplicationUser> userManager, string userName) 
        {
            this.userManager = userManager;
            if (ValidateUser(userName))
            {
                this.ImpersonateUser(userName);
            }
            else
            {
                throw new ImpersonateException("Current user does not have permissions to impersonate user");
            }
        }
        
        private bool ValidateUser(string userName) 
        {
            /* validate that the current user can impersonate userName */
        }
        public void Dispose()
        {
           this.RevertImpersonation();
        }
        private void ImpersonateUser(string userName) 
        {
           var context = HttpContext.Current;
           var originalUsername = context.User.Identity.Name;
           var impersonatedUser = this.userManager.FindByName(userName);
           var impersonatedIdentity = impersonatedUser.GenerateUserIdentity(this.userManager, "Impersonation");
           impersonatedIdentity.AddClaim(new Claim("UserImpersonation", "true"));
           impersonatedIdentity.AddClaim(new Claim("OriginalUsername", originalUsername));
           var impersonatedPrincipal = new ClaimsPrincipal(impersonatedIdentity);
           context.User = impersonatedPrincipal;
            Thread.CurrentPrincipal = impersonatedPrincipal;
        }
        private void RevertImpersonation()
        {
            var context = HttpContext.Current;
            if (!ClaimsPrincipal.Current.IsImpersonating())
            {
                throw new ImpersonationException("Unable to remove impersonation because there is no impersonation");
            }
            var originalUsername = ClaimsPrincipal.Current.GetOriginalUsername();
            var originalUser = this.userManager.FindByName(originalUsername);
            var originalIdentity = originalUser.GenerateUserIdentity(this.userManager);
            var originalPrincipal = new ClaimsPrincipal(originalIdentity);
            context.User = originalPrincipal;
            Thread.CurrentPrincipal = originalPrincipal;
        }
    }
