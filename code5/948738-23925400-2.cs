    public class CustomController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
           if (context.HttpContext.User.Identity.IsAuthenticated)
           {
               ...
           }
        }
    }
