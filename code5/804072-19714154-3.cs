    public class NInjectControllerFactory: DefaultControllerFactory {
        public IKernel Kernel { get; private set; }
        public NInjectControllerFactory() {
            Kernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType) {
            return controllerType == null
                ? null
                : (IController)Kernel.Get(controllerType);
        }
        private void AddBindings() {
            Kernel.Bind<IUnitOfWork>().To(typeof(EFDbContext)).InRequestScope();
			Kernel.Bind<IUserRepository>().To(typeof(EFUserRepository).InRequestScope();
        }
    }
