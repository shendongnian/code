    // Custom controller.
    public class CustomController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Do whatever here...
        }
    }
    
    // Home controller.
    public class HomeController : CustomController
    {
        // Action methods here...
    }
