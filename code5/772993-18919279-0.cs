    public class AppServiceRunner<T> : ServiceRunner<T>
    {
    	public AppServiceRunner(AppHost appHost, ActionContext actionContext)
    		: base(appHost, actionContext)
    	{
    	}
    
    	public override object HandleException(IRequestContext requestContext,
    		T request, Exception ex)
    	{	
    		LogException(requestContext, request, ex);
    
    		var responseStatus = ex.ToResponseStatus();
    		return DtoUtils.CreateErrorResponse(request, ex, responseStatus);
    	}
    
    	private void LogException(IRequestContext requestContext, T request, Exception ex)
    	{
    		// since AppHost.CreateServiceRunner can be called before AppHost.Configure
    		// don't get the logger in the constructor, only make it when it is needed
    		var logger = MakeLogger();
    		var requestType = typeof(T);
    		var message = string.Format("Exception at URI:'{0}' on service {1} : {2}",
    			requestContext.AbsoluteUri, requestType.Name, request.ToJson());
    
    		logger.Error(message, ex);
    	}
    
    	private static ILog MakeLogger()
    	{
    		return LogManager.GetLogger(typeof (AppServiceRunner<T>));
    	}
    }
