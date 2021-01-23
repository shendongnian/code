    public class MgsMvcControllerFactory : DefaultControllerFactory {
      protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) {
        // our controller instance will have dependency injection working
        if (!ServiceLocator.IoC.IsServiceRegistered(controllerType, controllerType.FullName)) {
          ServiceLocator.IoC.RegisterType(controllerType, controllerType.FullName, new ContainerControlledLifetimeManager())
        }
        return ServiceLocator.IoC.Resolve<IController>(controllerType.FullName);
      }
    }
