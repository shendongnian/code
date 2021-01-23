    public class MyExceptionFilterAttribute :
        System.Web.Mvc.FilterAttribute, 
        System.Web.Mvc.IExceptionFilter
    {
        public void OnException(System.Web.Mvc.ExceptionContext filterContext)
        {
            // same error handling logic as the controller override
        }
    }
