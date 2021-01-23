    public class CustomControllerFactory : DefaultControllerFactory
    {
        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            var controllerToken = requestContext.RouteData.GetRequiredString("controller");
            var context = new DbContext();
            var mappedRoute = context.RouteMaps.FirstOrDefault(r => r.DeviceId == controllerToken);
            if(mappedRoute == null) return base.GetControllerType(requestContext, controllerName);
            requestContext.RouteData.Values["controller"] = mappedRoute.ControllerShortName; //Example: "Home";
            return Type.GetType(mappedRoute.FullyQualifiedName);  //Example: "Web.Controllers.HomeController"
        }
    }
