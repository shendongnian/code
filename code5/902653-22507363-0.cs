     protected void Application_Error(object sender, EventArgs e)
            {
                var httpContext = ((MvcApplication)sender).Context;
                var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
                var currentController = " ";
                var currentAction = " ";
                if (currentRouteData != null)
                {
                    if (currentRouteData.Values["controller"] != null && !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                    {
                        currentController = currentRouteData.Values["controller"].ToString();
                    }
    
                    if (currentRouteData.Values["action"] != null && !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                    {
                        currentAction = currentRouteData.Values["action"].ToString();
                    }
                }
                var ex = Server.GetLastError();
                var url = Request.RawUrl;
                var controller = new ErrorController();
                var routeData = new RouteData();
                var action = "Error";
                httpContext.ClearError();
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
                httpContext.Response.TrySkipIisCustomErrors = true;
                routeData.Values["controller"] = "Error";
                routeData.Values["action"] = action;
                controller.ViewData.Model = new NameSpace.HandleErrorInfo(ex, currentController, currentAction);
                ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
            }
