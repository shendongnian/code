    public static void Register(HttpConfiguration config)
    {
    	config.Routes.MapHttpRoute( //MapHTTPRoute for controllers inheriting ApiController
    			name: "DefaultApi",
    			routeTemplate: "api/{controller}/{id}",
    			defaults: new { id = RouteParameter.Optional }
    	);
    }
