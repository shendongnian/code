    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin,   ApplicationUserRole, ApplicationUserClaim>
    {
      public string Gender { get; set; }
      public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
      {
        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        // Add custom user claims here
        return userIdentity;
      }
    }
