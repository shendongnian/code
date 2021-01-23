    public class CustomExceptionAttribute : FilterAttribute, IExceptionFilter
            {
                public void OnException(ExceptionContext filterContext)
                {
                    if (!filterContext.ExceptionHandled)
                    {
                        int val = (int)(((Exception)filterContext.Exception).ActualValue);
        
                       
                        filterContext.Result = new ViewResult
                        {
                            ViewName = "CustomError",
                            ViewData = new ViewDataDictionary<int>(val)
                        };
        
                        filterContext.ExceptionHandled = true;
                    }
                }
            }
