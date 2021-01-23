    //in WebApi Config Method
    config.MapHttpAttributeRoutes();
    
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<FullEntity>("FullData");
    builder.EntitySet<SubsetEntity>("SubsetData");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    
    
    config.Routes.MapHttpRoute(
      name: "DefaultApi",
      routeTemplate: "api/{controller}/{action}/{id}",
      defaults: new { id = RouteParameter.Optional, action = "GET" }
    );
    SetupJsonFormatters();
    config.Filters.Add(new UncaughtErrorHandlingFilterAttribute());
