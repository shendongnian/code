    public class MyControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(
            RequestContext requestContext, Type controllerType)
        {
            if (controllerType == typeof(_UsersController))
            {
                // Create controller here
                new _UsersController(service, currentUser, currentSettings);
            }
            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
    
