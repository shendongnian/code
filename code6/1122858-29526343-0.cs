    // Register the ServiceRoute
    public static void Register(HttpConfiguration config)
    {
      // Register the filter that will intercept the request before it is rooted to OData
      config.Filters.Add(CustomAuthenticationFilter>()); // If your dynamic parameter is related with Authentication use an IAuthenticationFilter otherwise you can register a MessageHandler for example.
      // Create the default collection of built-in conventions.
      var conventions = ODataRoutingConventions.CreateDefault();
      config.MapODataServiceRoute(
              routeName: "NameOfYourRoute",
              routePrefix: null, // Here you can define a prefix if you want
              model: GetEdmModel(), //Get the model
              pathHandler: new CustomPathHandler(), //Using CustomPath to handle dynamic parameter
              routingConventions: conventions); //Use the default routing conventions
    }
    
    // Just a filter to intercept the message before it hits the controller and to extract & store the DynamicValue
    public class CustomAuthenticationFilter : IAuthenticationFilter, IFilter
    {
	   // Extract the dynamic value
	   var dynamicValueStr = ((string)context.ActionContext.RequestContext.RouteData.Values["odatapath"])
            .Substring(0, ((string)context.ActionContext.RequestContext.RouteData.Values["odatapath"])
            .IndexOf('/')); // You can use a more "safer" way to parse
	
	   int dynamicValue;
	   if (int.TryParse(dynamicValueStr, out dynamicValue))
       {
	      // TODO (this I leave it to you :))
	      // Store it somewhere, probably at the request "context"
	      // For example as claim
       } 
    }
    // Define your custom path handler
    public class CustomPathHandler : DefaultODataPathHandler
    {
        public override ODataPath Parse(IEdmModel model, string serviceRoot, string odataPath)
        {
            // Code made to remove the "dynamicValue"
            // This is assuming the dynamicValue is on the first "/"
            int dynamicValueIndex= odataPath.IndexOf('/');
            odataPath = odataPath.Substring(dynamicValueIndex + 1);
            
            // Now OData will route the request normaly since the route will only have "/Products('ABC123')"
            return base.Parse(model, serviceRoot, odataPath);
        }
    }
