        public static class HttpRouteCollectionExtensions
        {
            public static IHttpRoute MapHttpRoute(this HttpRouteCollection routes, string name, string routeTemplate);
    
            public static IHttpRoute MapHttpRoute(this HttpRouteCollection routes, string name, string routeTemplate, object defaults);
    
            public static IHttpRoute MapHttpRoute(this HttpRouteCollection routes, string name, string routeTemplate, object defaults, object constraints);
         
            public static IHttpRoute MapHttpRoute(this HttpRouteCollection routes, string name, string routeTemplate, object defaults, object constraints, HttpMessageHandler handler);
        }
