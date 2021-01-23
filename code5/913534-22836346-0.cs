    public class HandleMyError : HandleErrorAttribute
        {
            public override void OnException( ExceptionContext filterContext )
            {
                if ( filterContext.ExceptionHandled ) { return ; }
                else
                {
                    string actionName = filterContext.RouteData.Values["action"].ToString();
                    Type controllerType = filterContext.Controller.GetType();
                    var method = controllerType.GetMethod( actionName );
                    var returnType = method.ReturnType;
    
                    if ( returnType.Equals( typeof( ActionResult ) ) || ( returnType ).IsSubclassOf( typeof( ActionResult ) ) )
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "area", "" }, { "controller", "Home" }, { "action", "Index" } });
                    }
                }
    
                filterContext.ExceptionHandled = true;
            }
        }
