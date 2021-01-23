    //global.asax
    protected void Application_Start() {
        //.... Omitted for brevity
        //Registering some regular mvc stuff
        //The two lines below populate the RouteTable.Routes
        AreaRegistration.RegisterAllAreas(); //add Area routes into the lookup table first such as the "Admin" area
        RegisterRoutes(RouteTable.Routes);  //followed by adding routes of classes implementing **IRouteProvider**
        //.... Omitted for brevity
    }
    
