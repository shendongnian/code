    public class CheckSessionOutAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower().Trim();
                string actionName = filterContext.ActionDescriptor.ActionName.ToLower().Trim();
                
                if (!actionName.StartsWith("login") && !actionName.StartsWith("sessionlogoff"))
                {
                    var session = HttpContext.Current.Session["SelectedSiteName"];
                    HttpContext ctx = HttpContext.Current;
                    //Redirects user to login screen if session has timed out
                    if (session == null)
                    {
                        base.OnActionExecuting(filterContext);
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "Account",
                            action = "SessionLogOff"
                        }));
                    }
                }
            }
            
        }
    }
