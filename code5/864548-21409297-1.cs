    public class CustomExceptionHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            handleException(filterContext);
        }
        private void handleException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.StatusDescription = HttpUtility.UrlEncode(filterContext.Exception.Message);
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.End();
        }
    }
