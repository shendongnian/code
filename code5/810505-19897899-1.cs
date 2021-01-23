    public class UnityControllerFactory : DefaultControllerFactory
    {
        private IUnityContainer container;
        private IControllerFactory defaultControllerFactory;
        public UnityControllerFactory()
        {
            container = new UnityContainer();
            defaultControllerFactory = new DefaultControllerFactory();
            RegisterTypes();
        }
        public override IController CreateController(RequestContext ctx, string controllerName)
        {
            try
            {
                return container.Resolve<IController>(controllerName);
            }
            catch 
            {
                return defaultControllerFactory.CreateController(ctx, controllerName);
            }
        }
        private void RegisterTypes()
        {
            container.RegisterType<IUserRepository, EFUserRepository>();
        }
    }
