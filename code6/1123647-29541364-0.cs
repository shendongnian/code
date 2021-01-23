    context.MapRoute(
                    "default_IT",
                    "IT",
                    new { action = "Index", controller = "ITHome" },
                    new[] { "YourAppNamespaceHere.Areas.IT.Controllers" }
                );
