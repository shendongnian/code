        protected void Application_Error(object sender, EventArgs e)
        {
             Exception ex = Server.GetLastError();
             if (HttpContext.Current.IsCustomErrorEnabled)
             {
                var controller = new ErrorController();
                var routeData = new RouteData();
                var action = "AccessDenied";
                if(ex is HttpRequestValidationException)
                {
                    action = "XSSError";
                }
                httpContext.ClearError();
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = ex is HttpException ?                     ((HttpException)ex).GetHttpCode() : 500;
                httpContext.Response.TrySkipIisCustomErrors = true;
                routeData.Values["controller"] = "Error";
                routeData.Values["action"] = action;
                ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
            }
       }
