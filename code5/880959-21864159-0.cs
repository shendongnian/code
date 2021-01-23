     public class ServiceAreaRegistration : AreaRegistration
        {
            public override string AreaName 
            {
                get{ return "Service";}
            }
    
            public override void RegisterArea(AreaRegistrationContext context)
            {
                context.Routes.MapHttpRoute(
                    name: "ServiceDefaultApi",
                    routeTemplate: "Service/api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            }
        }
