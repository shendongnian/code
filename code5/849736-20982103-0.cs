    routes.MapRoute(
                    "HomeEditStep1",
                    "EditStep1/{id}",
                    new { controller = "Home", action = "EditStep1", id = UrlParameter.Optional }, // Parameter defaults
                        new string[] { "MyProject.Web.Controllers" }
                );
