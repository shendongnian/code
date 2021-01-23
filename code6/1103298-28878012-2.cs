    public class MgsMvcControllerFactory : DefaultControllerFactory {
      protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) {
        // our controller instance will have dependency injection working
        if (!ServiceLocator.IoC.IsServiceRegistered(controllerType, controllerType.FullName)) {
          ServiceLocator.IoC.Register<IController>(controllerType, controllerType.FullName);
        }
        return ServiceLocator.IoC.Retrieve<IController>(controllerType.FullName);
      }
    }
