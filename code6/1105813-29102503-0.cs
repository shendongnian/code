    Protected void Application_Error(object sender, EventArgs e)
    {
            MvcApplication app = (MvcApplication)sender;
            HttpContext context = app.Context;
           Exception exc = Server.GetLastError();
    		if (exc.GetType() == typeof(HttpException))
                {
                    errorCode = ((HttpException)exc).GetHttpCode();
                }
                else if (exc.GetType() == typeof(Exception))
                {
                    errorCode = 500;
                }
    			var routeData = new RouteData();
                routeData.Values["controller"] = "{Your Controller}";
                routeData.Values["statusDescription"] = "{Your Description}";
                routeData.Values["action"] = "http500";
    
                switch (errorCode)
                {
                    case 404:
                          Server.ClearError();
                        routeData.Values["action"] = "Your action name";
                        break;
                    case 403:
                      
                        Server.ClearError();
                        routeData.Values["action"] = "Your action name";
                        break;
                    case 405:
                        
                        Server.ClearError();
                        routeData.Values["action"] = "Your action name";
                        break;
                    case 500:
                     
                        Server.ClearError();
                        routeData.Values["action"] = "Your action name";
                        break;
                    default:
                       
                        Server.ClearError();
                        routeData.Values["action"] = "Your action name";
                        break;
                }
    
                IController controller = new ErrorsController();
                controller.Execute(new RequestContext(new HttpContextWrapper(context), routeData));
    
                Server.ClearError();
        }
