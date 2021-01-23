    protected void Application_Start(object sender, EventArgs e)
    {
      RegisterRoutes(RouteTable.Routes);
    }        
    
    private void RegisterRoutes(RouteCollection routes)
    {
      routes.MapHttpHandlerRoute("MyRouteName", "Something/GetData/{par1}/{par2}/data.json", "~/MyHandler.ashx");
    }
