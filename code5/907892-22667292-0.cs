    var controller = new MyApiControllerClassToUnitTest();
    controller.Configuration = new HttpConfiguration();
    var route = controller.Configuration.Routes.MapHttpRoute(
                           name: "DefaultApi",
                              routeTemplate: "api/{controller}/{id}",
                               defaults: new { id = RouteParameter.Optional });
    var routeValues = new HttpRouteValueDictionary();
    routeValues.Add("controller", controllerPrefix);
    var routeData = new HttpRouteData(route, routeValues);
    
    controller.Request = new HttpRequestMessage(HttpMethod.GET, "http://someuri");
    controller.Request.Properties.Add(
                HttpPropertyKeys.HttpConfigurationKey, controller.Configuration);
    controller.Request.Properties.Add(HttpPropertyKeys.HttpRouteDataKey, routeData);
