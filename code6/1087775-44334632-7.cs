    private static string resolvePath<TController>(RouteValueDictionary routeValues, Expression<Action<TController>> expression) where TController : Http.Controllers.IHttpController {
        var controllerName = routeValues["controller"] as string;
        var actionName = routeValues["action"] as string;
        routeValues.Remove("controller");
        routeValues.Remove("action");
        var method = expression.AsMethodCallExpression().Method;
        var configuration = System.Web.Http.GlobalConfiguration.Configuration;
        var apiDescription = configuration.Services.GetApiExplorer().ApiDescriptions
           .FirstOrDefault(c =>
               c.ActionDescriptor.ControllerDescriptor.ControllerType == typeof(TController)
               && c.ActionDescriptor.ControllerDescriptor.ControllerType.GetMethod(actionName) == method
               && c.ActionDescriptor.ActionName == actionName
           );
        var route = apiDescription.Route;
        var routeData = new HttpRouteData(route, new HttpRouteValueDictionary(routeValues));
        var request = new System.Net.Http.HttpRequestMessage();
        request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = configuration;
        request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpRouteDataKey] = routeData;
        var virtualPathData = route.GetVirtualPath(request, routeValues);
        var path = virtualPathData.VirtualPath;
        return path;
    }
