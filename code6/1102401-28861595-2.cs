    public class HttpRequestValidationExceptionAttribute : FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                if (!filterContext.ExceptionHandled && filterContext.Exception is HttpRequestValidationException)
                {
                    IDictionary val = filterContext.Exception.Data;
    
               
                    filterContext.Result = new ViewResult
                    {
                        ViewName = "RangeError",
                        ViewData = new ViewDataDictionary<IDictionary>(val)
                    };
    
                    filterContext.ExceptionHandled = true;
                }
            }
        }
