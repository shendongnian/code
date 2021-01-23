    public class AutofacControllerFactory
        : DefaultControllerFactory
    {
        private readonly IContainer container;
        public InjectableControllerFactory(IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            this.container = container;
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (requestContext.HttpContext.Request.Url.ToString().EndsWith("favicon.ico"))
                return null;
            return controllerType == null ?
                base.GetControllerInstance(requestContext, controllerType) :
                this.container.Resolve(controllerType) as IController;
        }
    }
