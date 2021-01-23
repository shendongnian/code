    protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            //Not Found (When user digit unexisting url)
            if(ex is HttpException && ((HttpException)ex).GetHttpCode() == 404)
            {
                HttpContextWrapper contextWrapper = new HttpContextWrapper(this.Context);
                RouteData routeData = new RouteData();
                routeData.Values.Add("controller", "Error");
                routeData.Values.Add("action", "NotFound");
                IController controller = new ErrorController();
                RequestContext requestContext = new RequestContext(contextWrapper, routeData);
                controller.Execute(requestContext);
                Response.End();
            }
            else //Unhandled Errors from aplication
            {
                ErrorLogService.LogError(ex);
                HttpContextWrapper contextWrapper = new HttpContextWrapper(this.Context);
                RouteData routeData = new RouteData();
                routeData.Values.Add("controller", "Error");
                routeData.Values.Add("action", "Index");
                IController controller = new ErrorController();
                RequestContext requestContext = new RequestContext(contextWrapper, routeData);
                controller.Execute(requestContext);
                Response.End();
            }
        }
