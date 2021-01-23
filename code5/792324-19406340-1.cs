    public class NinjectControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext,
        Type controllerType)
        {
            return controllerType == null ? null : (IController)NinjectKernel.Kernel.Get(controllerType);
        }
    }
