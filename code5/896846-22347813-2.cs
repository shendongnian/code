    public static class WebApiConfig
    {
        //  TODO: Create test cases for custom routing.
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Routes.MapHttpRoute(
                name: "UpdateTitle",
                routeTemplate: "Playlist/UpdateTitle",
                defaults: new { controller = "PlaylistController", action = "UpdateTitle" }
             );    
                
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
    
        }
    }
