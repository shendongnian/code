     public class AdminAuthorizeAttribute: AuthorizeAttribute
         {
            
          protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
              {
                  return !base.AuthorizeCore(httpContext)? false:GetUsersecurityLevel();
              }
         }
