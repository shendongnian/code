    Your answer is Routing.
    
    http://msdn.microsoft.com/en-us/library/cc668201.aspx
    
    you will have to make changes to:
    
    protected void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(RouteTable.Routes);
    }
    
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.Add(new Route`enter code here`
        (
             "Category/{action}/{categoryName}"
             , new CategoryRouteHandler()
        ));
    }
