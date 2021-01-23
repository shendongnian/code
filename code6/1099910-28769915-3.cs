    //register your filter with Web API pipeline
    GlobalConfiguration.Configuration.Filters.Add(new LogExceptionFilterAttribute());
    //Create filter
    public class LogExceptionFilterAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            ErrorLogService.LogError(context.Exception);
        }
    }
    
    //in global.asax or global.asax.cs
    protected void Application_Error(object sender, EventArgs e)
    {
        Exception ex = Server.GetLastError();
        ErrorLogService.LogError(ex);
    } 
    
    //common service to be used for logging errors
    public static class ErrorLogService
    {
        public static void LogError(Exception ex)
        {
            //Email developers, call fire department, log to database etc.
        }
    }
