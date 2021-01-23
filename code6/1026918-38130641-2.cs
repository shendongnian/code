    public abstract class ExceptionHandlerService : IExceptionHandlerService
    {
    ILoggingService _loggingSerivce;
    protected ExceptionHandlerService(ILoggingService loggingService)
    {
        //Doing this allows my IoC component to resolve whatever I have
        //configured to log "stuff"
        _loggingService = loggingService;
    }
    public virtual void HandleException(Exception exception)
    {
        //I use elmah a alot - and this can handle WebAPI 
       //or Task.Factory ()=> things where the context is null
        if (Elmah.ErrorSignal.FromCurrentContext() != null)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
        }
        else
        {
            ErrorLog.GetDefault(null).Log(new Error(exception));
        }
        _loggingService.Log("something happened", exception)
        //re-direct appropriately
        var controller = new ErrorController();
        var routeData = new RouteData();
        var action = "CustomError";
        var statusCode = 500;
            statusCode = exception.GetHttpCode();
            switch (exception.GetHttpCode())
            {
                case 400:
                    action = "BadRequest";
                    break;
                case 401:
                    action = "Unauthorized";
                    break;
                case 403:
                    action = "Forbidden";
                    break;
                case 404:
                    action = "PageNotFound";
                    break;
                case 500:
                    action = "CustomError";
                    break;
                default:
                    action = "CustomError";
                    break;
             }
        //I didn't add the Authentication Error because that should be a separate filter that Autofac resolves.
       var httpContext = ((MvcApplication)sender).Context;
        httpContext.ClearError();
        httpContext.Response.Clear();
        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.TrySkipIisCustomErrors = true;
        routeData.Values["controller"] = "Error";
        routeData.Values["action"] = action;
        controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
        ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
    }
