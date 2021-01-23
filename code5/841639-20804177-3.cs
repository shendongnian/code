    public static class ClaimsAuthorizationHelper
    {
        public static bool CheckAccess(RequestContext requestContext)
        {
            var routeData = requestContext.RouteData;
            var controllerName = routeData.Values["controller"] as string;
            var actionName = routeData.Values["action"] as string;
            
            var controller = GetControllerByName(requestContext, controllerName);
            var controllerDescriptor = new ReflectedControllerDescriptor(controller.GetType());
            var controllerContext = new ControllerContext(requestContext, controller);
            var actionDescriptor = controllerDescriptor.FindAction(controllerContext, actionName);
            var resourceClaims = actionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof (ClaimsAuthorizeAttribute), false)
                .Cast<ClaimsAuthorizeAttribute>()
                .SelectMany(auth => auth.GetClaims()).ToList();
            resourceClaims.AddRange(actionDescriptor.GetCustomAttributes(typeof(ClaimsAuthorizeAttribute), false).Cast<ClaimsAuthorizeAttribute>()
                .SelectMany(c => c.GetClaims()));
            
            var hasAccess = ClaimsAuthorization.CheckAccess(actionName, resourceClaims.ToArray());
            return hasAccess;
        }
        public static ControllerBase GetControllerByName(RequestContext requestContext, string controllerName)
        {
            var factory = ControllerBuilder.Current.GetControllerFactory();
            var controller = factory.CreateController(requestContext, controllerName);
            if (controller == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The current controller factory, \"{0}\", did not return a controller for the name \"{1}\".", factory.GetType(), controllerName));
            }
            return (ControllerBase)controller;
        }
    }
