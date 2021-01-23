    public class ProfileCompletionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //this will prevent redirect for still unauthenticated users
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                return;
            //replace these to actual values of your profile completion action and controller
            string actionOfProfilePage = "Index";
            string controlerOfProfilePage = "Home";
            bool areWeAlreadyInProfilePage = filterContext.ActionDescriptor.ActionName == actionOfProfilePage
                && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == controlerOfProfilePage;
            if (areWeAlreadyInProfilePage) //this will prevent redirect loop
                return;
            bool isProfileComplete = false; //replace this with your custom logic
            if (!isProfileComplete)
            {                
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary 
                    { 
                        { "controller", controlerOfProfilePage }, 
                        { "action", actionOfProfilePage } 
                    });
            }
        }
    }
