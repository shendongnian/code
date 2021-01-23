        protected void Application_Error()
        {
            Exception ex = Server.GetLastError();
            if (ex is InvalidOperationException && ex.Message.Contains("or its master was not found or no view engine supports the searched locations. The following locations were searched"))
            {
                Server.ClearError();
                RouteData routeData = new RouteData();
                routeData.Values.Add("controller", "Error");
                routeData.Values.Add("action", "Error");
                routeData.Values.Add("id", 404);
                IController errorController = new ErrorController();
                errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
            }
        }
