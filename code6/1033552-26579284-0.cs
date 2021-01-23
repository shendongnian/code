    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        // other stuff
        Provider = new CookieAuthenticationProvider
        {
            // this function is executed every http request and executed very early in the pipeline
            // and here you have access to cookie properties and other low-level stuff. 
            // makes sense to have the invalidation here
            OnValidateIdentity = async context =>
            {
                // invalidate user cookie if user's security stamp have changed
                var invalidateBySecirityStamp = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager));
                await invalidateBySecirityStamp.Invoke(context);
                if (context.Identity == null || !context.Identity.IsAuthenticated)
                {
                    return;
                }
                // get user manager. It must be registered with OWIN
                var userManager = context.OwinContext.GetUserManager<UserManager>();
                var username = context.Identity.Name;
                
                // get new user identity with updated properties
                var updatedUser = await userManager.FindByNameAsync(username);
                
                // updated identity from the new data in the user object
                var newIdentity = updatedUser.GenerateUserIdentityAsync(manager);
                // kill old cookie
                context.OwinContext.Authentication.SignOut(context.Options.AuthenticationType);
                // sign in again
                var authenticationProperties = new AuthenticationProperties() { IsPersistent = context.Properties.IsPersistent };
                context.OwinContext.Authentication.SignIn(authenticationProperties, newIdentity);
            }
        }
    });  
    
