    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            // your code here
        }
    }
    public class HomeController : BaseController // instead of Controller
    {
        // ...
    }
