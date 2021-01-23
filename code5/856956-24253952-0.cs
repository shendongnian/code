     var subRouteData = request.GetRouteData().GetSubRoutes().LastOrDefault();
     if (subRouteData != null && subRouteData.Route != null)
     {
      var actions = subRouteData.Route.DataTokens["actions"] as HttpActionDescriptor[];
      if (actions != null && actions.Length > 0)
      {
         controllerName = actions[0].ControllerDescriptor.ControllerName;
      }
    }
