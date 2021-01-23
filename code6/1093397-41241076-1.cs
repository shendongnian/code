		public static class WebApiConfig
		{
			public static void Register(HttpConfiguration config)
			{
				// Web API configuration and services
		
				// Web API routes
				config.MapHttpAttributeRoutes();
		
				config.Routes.MapHttpRoute(
					name: "DefaultApi",
					routeTemplate: "api/{controller}/{id}",
					defaults: new { id = RouteParameter.Optional }
				);
		
				//This line sets json serializer's ContractResolver to CamelCasePropertyNamesContractResolver, 
				//	so API will return json using camel case
				config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
		
			}
		}
