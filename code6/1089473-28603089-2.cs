         public class ExceptionHandling : FilterAttribute, IExceptionFilter
            {
                public ILogger Logger { get; set; }
        
                public void OnException(ExceptionContext filterContext)
                {
                    Logger.Log("On Exception !", LogType.Debug, filterContext.Exception);
        
                    if (filterContext.Exception is UnauthorizedAccessException)
                    {
                        filterContext.Result = UnauthorizedAccessExceptionResult(filterContext);
                    }
                    else if (filterContext.Exception is BusinessException)
                    {
                        filterContext.Result = BusinessExceptionResult(filterContext);
                    }
                    else
                    {
                        // : Unhandled Exception
                        Logger.Log("Unhandled Exception ", LogType.Error, filterContext.Exception);
                        filterContext.Result = UnhandledExceptionResult(filterContext);
                    }
                } 
            }
