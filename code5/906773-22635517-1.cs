    using Microsoft.Owin.Security.DataProtection;
    using Microsoft.AspNet.Identity.Owin;
    // ...
    var provider = new DpapiDataProtectionProvider("SampleAppName");
    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>());
    userManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(
        provider.Create("SampleTokenName"));
