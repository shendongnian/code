         routes.MapRoute(
              "DefaultLocalized",
              "{language}-{culture}/{controller}/{action}/{id}",
              new
              {
                  controller = "Home",
                  action = "Index",
                  language = "da",
                  culture = "DK",
                  id = UrlParameter.Optional
              }
           );
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new
                {
                    controller = "Home",
                    action = "Index",
                    language = "en",
                    culture = "US",
                    id = UrlParameter.Optional
                } // Parameter defaults
            );
