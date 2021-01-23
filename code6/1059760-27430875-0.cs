    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            // Execute the normal exception handling routine...
            base.OnException(filterContext);            
                        
            if (filterContext.Exception is HttpException)
            {
                var httpException = filterContext.Exception as HttpException; 
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
    And, in your `FilterConfig` class under `App_Start`:
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomHandleErrorAttribute());
        }
    }
