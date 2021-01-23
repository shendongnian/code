     protected void Application_Error(object sender, EventArgs e)
                {
                    var ex = Server.GetLastError().GetBaseException();
                    Server.ClearError();
        
                    var routeData = new RouteData();
                    routeData.Values.Add("controller", "Error");
                    routeData.Values.Add("action", "Global");
                    int status = 0;
        
                    if (ex.GetType() == typeof(HttpException))
                    {
                        var httpException = (HttpException)ex;
                        var code = httpException.GetHttpCode();
                        status = code;
                    }
                    else
                    {
                        status = 500;
                    }
        
                    //Create a new error based off the exception and the error status.
                    NameSpace.Models.ErrorModel Error = new ErrorModel(status, ex);
                    string innerException = "";
                    if (ex.InnerException != null)
                    {
                        innerException = "\n Inner Ex: " + ex.InnerException.StackTrace;
                    }
        
                    log.Error("Error Id: " + Error.ErrorId + " Error: " + ex.Message + ". Stack Trace: " + ex.StackTrace + innerException);
                    routeData.Values.Add("error", Error);
        
                    IController errorController = new NameSpace.Controllers.ErrorController();
                    errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        
        
                }
