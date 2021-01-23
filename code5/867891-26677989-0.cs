    public class NotImplExceptionFilterAttribute : ExceptionFilterAttribute
    {
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public override void OnException(HttpActionExecutedContext context)
        {
            RequestData requestData = new RequestData(context.Request);
            log.Error("NotImplExceptionFilterAttribute", context.Exception);
                context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
        }
    }
