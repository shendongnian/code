                routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "controller Name", action = "action name", id = UrlParameter.Optional }, // Parameter defaults
                new[] { "Your Area Controller Namespace" }
            );
