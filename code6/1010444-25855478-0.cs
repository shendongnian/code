     public class MyAuthAttribute : AuthorizeAttribute
     {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var routeData = actionContext.ControllerContext.RouteData;
    
            //If you don't have an action name, I've assumed "index" is the default.
            var actionName = routeData.Values.ContainsKey("id") ? routeData.Values["id"].ToString() : "Index";
    
            //you can then get the method via reflection...
            var attribs = actionContext.ControllerContext.Controller.GetType()
                        .GetMethod(actionName, BindingFlags.Public | BindingFlags.Instance)
                        .GetCustomAttributes();
                
            //Do something...
   
            return base.IsAuthorized(actionContext);
        }
    }
