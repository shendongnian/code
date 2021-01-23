    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            RouteData.Values.Add("MyKey", "MyValue");
            base.OnActionExecuting(filterContext);
        }
    }
