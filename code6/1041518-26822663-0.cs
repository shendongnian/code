    public class CustomControllerFactory : DefaultControllerFactory {
        protected override Type GetControllerType(RequestContext requestContext, 
            string controllerName) {
            string tenant = requestContext.HttpContext.Request.QueryString["tenant"];
            string[] namespaces;
            if (tenant != null) {
                namespaces = new[] { "MyComp.Plugins." + tenant };
            } else {
                namespaces = new[] { typeof(HomeController).Namespace };
            }
            requestContext.RouteData.DataTokens["Namespaces"] = namespaces;
            var type = base.GetControllerType(requestContext, controllerName);
            return type;
        }
    }
