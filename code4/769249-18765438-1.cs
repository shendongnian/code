        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception == null) return;
            Type exceptionType = filterContext.Exception.GetType();
            if (exceptionType == typeof(StatusException))
            {
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.ContentEncoding = Encoding.UTF8;
                filterContext.HttpContext.Response.HeaderEncoding = Encoding.UTF8;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.HttpContext.Response.StatusDescription = filterContext.Exception.Message;
            }
         }
