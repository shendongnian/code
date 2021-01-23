    internal class CustomControllerFactory : DefaultControllerFactory
    {
        internal const string ParentActionViewContextToken = "ParentActionViewContext";
        private readonly IResolutionRoot _resolutionRoot;
        public CustomControllerFactory(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
        }
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            //You can improve this later if you want -> you'll need to figure out if your controller will fit into this case
            //You can use marker interfaces, common supertype, etc... that's up to you
            if (controllerName.Equals("home", StringComparison.InvariantCultureIgnoreCase))
            {
                var controllerType = typeof (HomeController);
                var isChild = requestContext.RouteData.DataTokens.ContainsKey(ParentActionViewContextToken);
                var constructorArgument = new ConstructorArgument("someName", (isChild) ? "Child" : "Nope");
                var requestForDependency = _resolutionRoot.CreateRequest(typeof(IServiceClient), null, new Parameter[] { constructorArgument }, true, true);
                var dependency = _resolutionRoot.Resolve(requestForDependency).SingleOrDefault();
                return (IController)_resolutionRoot.Get(controllerType, new ConstructorArgument("service", dependency));
            }
            //Will go through the default pipeline (IDependencyResolver will be called, not affecting DI of other controllers)
            return base.CreateController(requestContext, controllerName);
        }
    } 
 
