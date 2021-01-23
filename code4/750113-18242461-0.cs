    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);
    }
    void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("random", "random", "~/index.html");
    }
