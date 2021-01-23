    protected void Application_Error(object sender, EventArgs e)
    {
       var httpContext = ((MvcApplication)sender).Context;
        
       var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
    }
