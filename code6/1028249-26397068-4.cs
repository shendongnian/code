    public class LogApiRequest : ActionFilterAttribute
    	{
    		public override void OnActionExecuting(HttpActionContext actionContext)
    		{
    			var text =  actionContext.Request.Content.ReadAsStringAsync().Result;
    			MyLogger.Log(LogLevel.INFO, text);
    
    			base.OnActionExecuting(actionContext);
    		}
    	}
