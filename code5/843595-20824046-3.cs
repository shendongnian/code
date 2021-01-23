    protected void Application_Error()
    {
        var exception = Server.GetLastError();
        var httpException = exception as HttpException;
        Response.Clear();
        Server.ClearError();
        var routeData = new RouteData();
        routeData.Values["controller"] = "Errors";
        routeData.Values["action"] = "Http500";
        routeData.Values["exception"] = exception;
        Response.StatusCode = 500;
        Response.TrySkipIisCustomErrors = true;
        if (httpException != null)
        {
            Response.StatusCode = httpException.GetHttpCode();
            switch (Response.StatusCode)
            {
                case 403:
                    routeData.Values["action"] = "Http403";
                    break;
                case 404:
                    routeData.Values["action"] = "Http404";
                    break;
                // TODO: Add other cases if you want to handle
                // different status codes from your Web API
            }
        }
    
        IController errorsController = new ErrorsController();
        var rc = new RequestContext(new HttpContextWrapper(Context), routeData);
        errorsController.Execute(rc);
    }
