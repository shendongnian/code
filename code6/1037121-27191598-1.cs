    public static void Register(HttpConfiguration config)
    {
    	config.MapHttpAttributeRoutes(); //This has to be called before the following OData mapping, so also before WebApi mapping
    
    	ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    
    	builder.EntitySet<Site>("Sites");
    	//Moar!
    
    	config.MapODataServiceRoute("ODataRoute", "api", builder.GetEdmModel());
    }
