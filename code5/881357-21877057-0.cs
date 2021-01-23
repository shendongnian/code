    void RegisterRoutes(RouteCollection routes)
    {
    
        routes.MapPageRoute(
        "default-page",
        "default",
        "~default.aspx"
        );
    }
    void Application_Start()
    {
        RegisterRoutes(RouteTable.Routes);
    }
