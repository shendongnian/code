     routes.MapRoute(
                        "myname",                                              // Route name
                        "{controller}/{action}/{details}/{myname}",                           // URL with parameters
                        new { controller = "mycontroller", action = "myaction", details= UrlParameter.Optional, myname= UrlParameter.Optional }  // Parameter defaults
                    );
