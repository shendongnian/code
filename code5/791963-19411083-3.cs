    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
          var ex = filterContext.Exception;
          //     Open database connection
          //     Save exception details.
          //     If connection cannot be made to the database save exception in a text file.
        }
     }
