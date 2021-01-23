      public class AuthenticateAndAuthorizeAcsMvcAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            var principal = filterContext.HttpContext.User;
            if (principal == null || !principal.Identity.IsAuthenticated)
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "AcsLogin",
                    ViewData = filterContext.Controller.ViewData,
                    TempData = filterContext.Controller.TempData
                };
                return;
            }
            base.OnAuthorization(filterContext);
        }
    }
