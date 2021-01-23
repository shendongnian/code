    public class MyCustomAuthorizeAttribute: AuthorizeAttribute
    {
       protected override bool AuthorizeCore(HttpContextBase httpContext)
       {
          #if DEBUG
            return true;
          #else
          return base.AuthorizeCore(httpContext);
       }
       public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
       {
          #if DEBUG
          // CHANGE TO YOUR USER MANAGER
          var userManger = filterContext.HttpContext.GetOwinContext().GetUserManager<ApplicationUser>();
          var user = userManger.FindByName("***");
          if (user == null)
             this.Create(new ApplicationUser {/* ... */}, "***");
          using(var signInManager = new ApplicationSignInManager(userManger, filterContext.HttpContext.GetOwinContext().Authentication))
             signInManager.PasswordSignIn(user.UserName, "***", true, false);
        
          return true;
          #endif
          return base.OnAuthorization(filterContext);
       }
    }
