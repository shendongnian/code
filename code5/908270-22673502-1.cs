    protected void Application_Error(object sender, EventArgs e)
    {
        var httpContext = ((MvcApplication)sender).Context;
        var currentController = " ";
        var currentAction = " ";
        var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
        if (currentRouteData != null)
        {
            if (currentRouteData.Values["controller"] != null && 
                !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
            {
                currentController = currentRouteData.Values["controller"].ToString();
            }
            if (currentRouteData.Values["action"] != null && 
                !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
            {
                currentAction = currentRouteData.Values["action"].ToString();
            }
        }
        var ex = Server.GetLastError();
        var controller = new ErrorController();
        var routeData = new RouteData();
        var action = "Index";
        var statusCode = 500;
        if (ex is ArgumentException)
        {
            action = "NotFound";
            statusCode = 404;
        }
        httpContext.ClearError();
        httpContext.Response.Clear();
        httpContext.Response.StatusCode = statusCode;             
        httpContext.Response.TrySkipIisCustomErrors = true;
        routeData.Values["controller"] = "Error";
        routeData.Values["action"] = action;
        controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
        ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
    }
