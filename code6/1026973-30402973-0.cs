    public class CustomErrorException: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new ViewResult {
                ViewName = "CustomError",
                ViewData = new ViewDataDictionary<HandleErrorInfo> { 
                    Model = new HandleErrorInfo(
                        exception: filterContext.Exception,
                        controllerName: filterContext.RequestContext.RouteData.Values["controller"].ToString(),
                        actionName: filterContext.RequestContext.RouteData.Values["action"].ToString()
                    ) 
                }
            };
            
            //You can log your errors here.
            filterContext.ExceptionHandled = true;
        }
    }
