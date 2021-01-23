                // Web API configuration and services
                    
                config.MapHttpAttributeRoutes();  // this line had issue
    
                var constraintResolver = new DefaultInlineConstraintResolver();
                constraintResolver.ConstraintMap.Add("nonzero", typeof(NonZeroConstraint));
                config.MapHttpAttributeRoutes(constraintResolver);
    
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            }
