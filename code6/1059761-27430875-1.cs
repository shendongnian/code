    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            // Execute the normal exception handling routine...
            base.OnException(filterContext);            
                        
            var exception = filterContext.Exception;
            if (exception is HttpException)
            {
                var httpException = exception as HttpException; 
                if(httpException.ErrorCode == 404)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { 
                        action = "PageNotFound", 
                        controller = "Error",
                        error = httpException.Message
                    }));                
                }
                // else if...
            }
        }
    }
