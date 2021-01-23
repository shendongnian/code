    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
      public override async Task<System.Security.Claims.ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
      {
          var identity = await base.CreateUserIdentityAsync(user);
          identity.AddClaim(new System.Security.Claims.Claim("IsBirthday", user.DOB.GetShortDateString() == DateTime.Now.GetShortDateString()));
          return identity;
      }
      
      // ... EXCLUDING OTHER STUFF LIKE CONSTRUCTOR AND OWIN FACTORY METHODS ...
    }
