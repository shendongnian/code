    public void Application_Start(object sender, EventArgs e)
    {
        RouteTable.Routes routeCollection;
        routeCollection.MapPageRoute("DefaultRoute", string.Empty, "~/YourDesiredSubFolder/YourDesiredDocument.aspx");
    }
