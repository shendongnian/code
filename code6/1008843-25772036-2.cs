    public class RoleAttribute : AuthorizeAttribute
        {
            public string UserRole { get; set; }
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                return (httpContext.Request.IsAuthenticated && httpContext.User.IsInRole(UserRole));
            }
            //if AuthorizeCore return false
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                //add to session
                filterContext.RequestContext.HttpContext.Session["aa"] = "Hey! You haven't access!";
                string action = "";
                string controller = "";
                //get current action
                if (filterContext.Controller.ControllerContext.RouteData.Values["action"] != null)
                {
                    action = filterContext.Controller.ControllerContext.RouteData.Values["action"].ToString();
                }
                //get current controller
                if (filterContext.Controller.ControllerContext.RouteData.Values["controller"] != null)
                {
                    controller = filterContext.Controller.ControllerContext.RouteData.Values["controller"].ToString();
                }
                //redirect to register method and for example add some info - returnUrl
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new
                        {
                            controller = "Account",
                            action = "Register",
                            returnUrl = string.Format("{0}/{1}",controller,action)
                        })
                    );
            }
        }
