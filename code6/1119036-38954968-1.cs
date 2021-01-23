        public static class SlidingSecurityStampValidator
        {
        	private static readonly IDictionary<string, DateTimeOffset> IdentityValidationDates = new Dictionary<string, DateTimeOffset>();
        
        	public static Func<CookieValidateIdentityContext, Task> OnValidateIdentity<TManager, TUser, TKey>(
        		TimeSpan validateInterval, Func<TManager, TUser, Task<ClaimsIdentity>> regenerateIdentityCallback,
        		Func<ClaimsIdentity, TKey> getUserIdCallback)
        		where TManager : UserManager<TUser, TKey>
        		where TUser : class, IUser<TKey>
        		where TKey : IEquatable<TKey>
        	{
        		if (getUserIdCallback == null)
        		{
        			throw new ArgumentNullException(nameof(getUserIdCallback));
        		}
        
        		return async context =>
        		{
        			var currentUtc = DateTimeOffset.UtcNow;
        			if (context.Options != null && context.Options.SystemClock != null)
        			{
        				currentUtc = context.Options.SystemClock.UtcNow;
        			}
        			var issuedUtc = context.Properties.IssuedUtc;
        
        			// Only validate if enough time has elapsed
        			var validate = issuedUtc == null;
        			if (issuedUtc != null)
        			{
        				DateTimeOffset lastValidateUtc;
        				if (IdentityValidationDates.TryGetValue(context.Identity.Name, out lastValidateUtc))
        				{
        					issuedUtc = lastValidateUtc;
        				}
        
        				var timeElapsed = currentUtc.Subtract(issuedUtc.Value);
        				validate = timeElapsed > validateInterval;
        			}
        
        			if (validate)
        			{
        				IdentityValidationDates[context.Identity.Name] = currentUtc;
        
        				var manager = context.OwinContext.GetUserManager<TManager>();
        				var userId = getUserIdCallback(context.Identity);
        				if (manager != null && userId != null)
        				{
        					var user = await manager.FindByIdAsync(userId);
        					var reject = true;
        
        					// Refresh the identity if the stamp matches, otherwise reject
        					if (user != null && manager.SupportsUserSecurityStamp)
        					{
        						var securityStamp = context.Identity.FindFirstValue(Constants.DefaultSecurityStampClaimType);
        						if (securityStamp == await manager.GetSecurityStampAsync(userId))
        						{
        							reject = false;
        							// Regenerate fresh claims if possible and resign in
        							if (regenerateIdentityCallback != null)
        							{
        								var identity = await regenerateIdentityCallback.Invoke(manager, user);
        								if (identity != null)
        								{
        									// Fix for regression where this value is not updated
        									// Setting it to null so that it is refreshed by the cookie middleware
        									context.Properties.IssuedUtc = null;
        									context.Properties.ExpiresUtc = null;
        									context.OwinContext.Authentication.SignIn(context.Properties, identity);
        								}
        							}
        						}
        					}
        
        					if (reject)
        					{
        						context.RejectIdentity();
        						context.OwinContext.Authentication.SignOut(context.Options.AuthenticationType);
        					}
        				}
        			}
        		};
        	}
        }
