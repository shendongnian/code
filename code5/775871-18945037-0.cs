    public class SecurityAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["User"] == null)
            {
                var values = new
                {
                    controller = "Login",
                    action = "DoLogin",
                    returnUrl = filterContext.HttpContext.Request.Url.AbsoluteUri
                };
                var result = new RedirectToRouteResult("Default", new RouteValueDictionary(values));
                filterContext.Result = result;
            }
        }
    }
