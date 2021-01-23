    // NOTE: Something like this, not exactly, I've not used Ninject!
    public class YourControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var type = GetControllerType(requestContext, controllerName);
            return kernel.Get(type);
        }
    }
