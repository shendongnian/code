    public class BaseController : Controller {
        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            ViewBag.UserName =
                filterContext.HttpContext.User.Identity.IsAuthenticated
                    ? filterContext.HttpContext.User.Identity.Name
                    : "GUEST";
            base.OnActionExecuting(filterContext);
        }
    }
