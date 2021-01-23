    protected override IReadOnlyList<IDirectRouteFactory> GetControllerRouteFactories(HttpControllerDescriptor controllerDescriptor)
    {
      // Inherit route attributes decorated on base class controller
      // GOTCHA: RoutePrefixAttribute doesn't show up here, even though we were expecting it to.
      //  Am keeping this here anyways, but am implementing an ugly fix by overriding GetRoutePrefix
      return controllerDescriptor.GetCustomAttributes<IDirectRouteFactory>(true);
    }
    protected override IReadOnlyList<IDirectRouteFactory> GetActionRouteFactories(HttpActionDescriptor actionDescriptor)
    {
      // Inherit route attributes decorated on base class controller's actions
      return actionDescriptor.GetCustomAttributes<IDirectRouteFactory>(true);
    }
