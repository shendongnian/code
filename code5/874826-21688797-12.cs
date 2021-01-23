    public class AuthorizeExAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            Ensure.Argument.NotNull(filterContext);
            base.OnAuthorization(filterContext);
            IPrincipal user = filterContext.HttpContext.User;
            if (user.Identity.IsAuthenticated)
            {
                var ctrl = filterContext.Controller as BaseController;
                ctrl.WorkContext = new WorkContext(user.Identity.Name);
            }
        }
    }
