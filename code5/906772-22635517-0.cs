    using Microsoft.Owin.Security.DataProtection;
    using Microsoft.AspNet.Identity.Owin;
    // ...
    var provider = new DpapiDataProtectionProvider("Sample");
    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>());
    userManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(
        provider.Create("EmailConfirmation"));
