    public class UnitySessionControllerFactory : DefaultControllerFactory
    {
        private const string HttpContextKey = "Container";
        private readonly IUnityContainer _container;
        public UnitySessionControllerFactory (IUnityContainer container)
        {
            _container = container;
        }
        protected IUnityContainer GetChildContainer(RequestContext requestContext)
        {
            var routeData = requestContext.RouteData.Values
			?? new RouteValueDictionary();
            var clientName = routeData["clientName"] as string;
            var packageId = routeData["packageID"] as int?;
            if (clientName == null)
                throw new ArgumentException("ClientName not included in route parameters");
            var childContainer = requestContext.HttpContext.Session[clientName + HttpContextKey] as IUnityContainer;
            if (childContainer != null)
                return childContainer;
            requestContext.HttpContext.Session[clientName + HttpContextKey] = childContainer = _container.CreateChildContainer();
            var moduleLoader = childContainer.Resolve<ModuleLoader>();
            moduleLoader.LoadModules(clientName, packageId);
            return childContainer;
        }
 
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controllerType = GetControllerType(requestContext, controllerName);
            var container = GetChildContainer(requestContext);
            return container.Resolve(controllerType) as IController;
        }
 
        public override void ReleaseController(IController controller) 
        {
            _container.Teardown(controller);
        }
    }
