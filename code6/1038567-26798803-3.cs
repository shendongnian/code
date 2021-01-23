        public readonly IContainer Container;
        private readonly string moduleName;
        public AutofacControllerFactory(IContainer container, string moduleName)
        {
            this.Container = container;
            this.moduleName = moduleName;
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                // The base method throws an expressive 404 HTTP error.
                base.GetControllerInstance(requestContext, controllerType);
            }
            // We need to start a new lifetime scope when resolving a controller.
            // NOTE: We can apply MatchingScopeLifetimeTags.RequestLifetimeScopeTag to the BeginLifetimeScope
            // method and in this case we can use .InstancePerRequest(), but in that case it becomes impossible to
            // verify the DI configuration in an integration test.
            ILifetimeScope lifetimeScope = this.Container.BeginLifetimeScope();
            // We need to store this lifetime scope during the request to allow to retrieve it when the controller
            // is released and to allow to dispose the scope. Memory leaks will be ensured if we don't do this.
            HttpContext.Current.Items[controllerType.FullName + "_lifetimeScope"] = lifetimeScope;
            // This call will throw an exception when we start making registrations with .InstancePerRequest, 
            // because the WebRequest functionality of Autofac is tied to the AutofacDependencyResolver, which we
            // don't use here. We can't use the AutofacDependencyResolver here, since it stores the created lifetime 
            // scope in the HttpContext.Items, but it uses a fixed key, which means that if we resolve multiple
            // controllers for different application modules, they will all reuse the same lifetime scope, while
            // this scope originates from a single container.
            try
            {
                return (IController)lifetimeScope.Resolve(controllerType);
            }
            catch (Exception ex)
            {
                lifetimeScope.Dispose();
                throw new InvalidOperationException("The container of module '" + this.moduleName +
                    "' failed to resolve controller " + controllerType.FullName + ". " + ex.Message, ex);
            }
        }
        [DebuggerStepThrough]
        public override void ReleaseController(IController controller)
        {
            try
            {
                base.ReleaseController(controller);
            }
            finally
            {
                var scope = (ILifetimeScope)HttpContext.Current
                    .Items[controller.GetType().FullName + "_lifetimeScope"];
                scope.Dispose();
            }
        }
    }
