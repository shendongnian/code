    public class ConnectionSelector {
        public bool AsReadOnly { get; set; }
    }
    private class ReadOnlySwitchControllerFactory : DefaultControllerFactory {
        private readonly Container container;
        public ReadOnlySwitchControllerFactory(Container container) {
            this.container = container;
        }
        protected override IController GetControllerInstance(RequestContext requestContext, 
            Type controllerType) {
            var selector = this.container.GetInstance<ConnectionSelector>();
            selector.AsReadOnly = 
                typeof(IReadOnlyController).IsAssignableFrom(controllerType);
            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
