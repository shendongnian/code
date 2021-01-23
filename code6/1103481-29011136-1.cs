    @using Microsoft.AspNet.Identity
    @using Microsoft.AspNet.Identity.Owin;
    @if (Request.IsAuthenticated) {
      var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
      var userRoles = userManager.GetRoles(User.Identity.GetUserId());
      var role = userRoles[0];
    }
