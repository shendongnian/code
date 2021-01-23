    public class DatabaseErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            // log exception and other details
        }
    }
