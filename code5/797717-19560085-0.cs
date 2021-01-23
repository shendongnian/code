    var attributedRoutesData = request.GetRouteData().GetSubRoutes();
    var subRouteData = attributedRoutesData.FirstOrDefault();
    
    var actions = (ReflectedHttpActionDescriptor[])subRouteData.Route.DataTokens["actions"];
    var controllerName = actions[0].ControllerDescriptor.ControllerName;
