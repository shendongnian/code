    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory(IKernel kernel)
        {
            ninjectKernel = kernel;
        }
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            try
            {
                Type controllerType = base.GetControllerType(requestContext, controllerName);
                return ninjectKernel.Get(controllerType) as IController;
            }
            catch (Exception)
            {
                return base.CreateController(requestContext, controllerName);
            }
        }
    }
