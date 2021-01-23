    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!(filterContext.Exception is InvalidOperationException))
            {
                // log
            }
        }
    }
