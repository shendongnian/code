    public class CustomControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var user = HttpContext.Current.User;
            if (user.Identity.IsAuthenticated)
            {
                return base.CreateController(requestContext, controllerName);
            }
            var routeValues = requestContext.RouteData.Values;
            routeValues["action"] = "PreAuth";
            return base.CreateController(requestContext, "Auth");
        }
    }
