     protected void Application_Error()
        {
            var exception = Server.GetLastError();
            Server.ClearError();
            var httpException = exception as HttpException;
    
            //Logging goes here
    
            var routeData = new RouteData();
            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = "Index";
    
            if (httpException != null)
            {
                switch(httpException.GetHttpCode())
                {
                    case 401:
                        routeData.Values["action"] = "NotAuthorised";
                        break;
                    case 402:
                    case 403:
                        routeData.Values["action"] = "NotAuthorised";
                        break;
                    case 404:
                        routeData.Values["action"] = "NotFound";
                        break;
                }
    
                Response.StatusCode = httpException.GetHttpCode();
            }
            else
            {
                Response.StatusCode = 500;
            }
    
            // Avoid IIS7 getting involved
            Response.TrySkipIisCustomErrors = true;
    
            // Execute the error controller
            IController errorsController = new Jmp.StaticMeasures.Controllers.ErrorController();
            HttpContextWrapper wrapper = new HttpContextWrapper(Context);
            var rc = new RequestContext(wrapper, routeData);
            errorsController.Execute(rc);
        }
