    public static void Register(HttpConfiguration config)
            {
                 config.Routes.MapHttpRoute(
                  name: "ApiByName",
                  routeTemplate: "api/{controller}/{action}/{name}",
                  defaults: null,
                  constraints: new { name = @"^[a-z]+$" }
                 );
                config.Routes.MapHttpRoute(
                    name: "ApiByAction",
                    routeTemplate: "api/{controller}/{action}",
                    defaults: new { action = "Get" }
                );
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
           
            }
