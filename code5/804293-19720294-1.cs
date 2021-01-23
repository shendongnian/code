    using System.IO;
    using System.Web.Mvc;
    
    namespace CL.Enterprise.Components.Web.Mvc
    {
    	/// <summary>
    	/// Extension methods for System.Web.Mvc.Controller
    	/// </summary>
    	public static class ContollerExtensions
    	{
    		/// <summary>
    		/// Method to return a JsonPResult
    		/// </summary>
    		public static JsonPResult JsonP(this Controller controller, object data)
    		{
    			JsonPResult result = new JsonPResult();
    			result.Data = data;
    			//result.ExecuteResult(controller.ControllerContext);
    			return result;
    		}
    
    		/// <summary>
    		/// Get the currently named jsonp QS parameter value
    		/// </summary>
    		public static string GetJsonPCallback(this Controller controller)
    		{
    			return 
    				controller.ControllerContext.RequestContext.HttpContext.Request.QueryString["callback"] ?? 
    				controller.ControllerContext.RequestContext.HttpContext.Request.QueryString["jsoncallback"] ?? 
    				string.Empty;
    		}
    	}
    }
