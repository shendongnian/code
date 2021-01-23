    HttpConfiguration oldCofiguration = OtherWebService.Startup.Config;
    HttpConfiguration newCofiguration = new HttpConfiguration();
    foreach(var oldRoute in oldCofiguration.Routes){
        newCofigurationRoutes.MapHttpRoute(
                "YourRouteName",
                "yourPrefix" + oldRoute .routeTemplate ,
                new
                {
                    controller = oldRoute.Controller
                },
                null,
                null
                );
    }
