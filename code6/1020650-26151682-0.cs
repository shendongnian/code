     public class AdminAuthorizeAttribute: AuthorizeAttribute
         {
            
          protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
              {
    // your logic here
                   return GetUsersecurityLevel();
                }
              }
         }
