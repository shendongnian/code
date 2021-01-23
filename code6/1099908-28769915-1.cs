    using System.Web.Http.Filters;
    public class NotImplExceptionFilterAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            ErrorLogService.LogError(context.Exception);
        }
    }
    
    protected void Application_Error(object sender, EventArgs e)
    {
        Exception ex = Server.GetLastError();
        ErrorLogService.LogError(ex);
    } 
    
    public class ErrorLogService
    {
        public static void LogError(Exception ex)
        {
            //Email developers, call fire department, log to database etc.
        }
    }
