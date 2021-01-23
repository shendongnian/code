        public class CustomController : Controller
        {
            protected override void OnActionExecuting(ActionExecutingContext filterContext)
            {
    
                if (!LoggedIn) //Here you decide how to check if the user is Logged in
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "YourLogInControllerName",
                        action = "YourLoginActionName"
                    }));
                }
                else
                {
                    base.OnActionExecuting(filterContext);
                }
            }
        }
