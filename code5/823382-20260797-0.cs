    public class BlackBoxAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorized = base.AuthorizeCore(httpContext);
    
            if (authorized)
            {
                var routeData = httpContext.Request.RequestContext.RouteData;
                var controller = routeData.GetRequiredString("controller");
                var action = routeData.GetRequiredString("action");
    
                bool canAccess = BlackBox.HasAccess(controller, action, userGuid);
    
                if (!canAccess)
                {
                    httpContext.Items["BlackBoxError"] = true;
                    return false;
                }
    
                return true;
            }
            else
            {
                return authorized;
            }
        }
    
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            bool blackBoxError = filterContext.HttpContext.Items["BlackBoxError"] != null && Convert.ToBoolean(filterContext.HttpContext.Items["BlackBoxError"].ToString());
    
            if (blackBoxError)
            {
                //change the controler name and action name accordingally as needed.
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                                                            {
                                                                                { "controller", "Error" }, 
                                                                                { "action", "BlackBoxError" } 
                                                                            }
                                                                        );
            }
    
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
