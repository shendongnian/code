    protected override void OnException(ExceptionContext filterContext)
            {
                if (filterContext.ExceptionHandled)
                    return;
   
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Error.cshtml",
                    ViewData = new ViewDataDictionary {{"Exception", filterContext.Exception.Message}}
                };
                
                filterContext.ExceptionHandled = true;
            }
