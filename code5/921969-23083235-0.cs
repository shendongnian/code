    config.Routes.MapHttpRoute
                    (
                        "DefaultInternalApi",
                        "api/{controller}/{objectType}/{Id}/{relation}",
                        defaults:
                                new
                                {
                                    Id = System.Web.Http.RouteParameter.Optional,
                                }
                    );
