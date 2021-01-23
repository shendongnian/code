    using System;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;
    
    namespace CL.Enterprise.Components.Web.Mvc
    {
    	/// <summary>
    	/// Extension of JsonResult to handle JsonP requests
    	/// </summary>
    	public class JsonPResult : ActionResult
    	{
    		private JavaScriptSerializer _jser = new JavaScriptSerializer();				
    		
    		public Encoding ContentEncoding { get; set; }
    		public string ContentType { get; set; }
    		public object Data { get; set; }
    		public string JsonCallback { get; set; }
    
    		public JsonPResult() { }
    
    		/// <summary>
    		/// Package and return the result
    		/// </summary>
    		public override void ExecuteResult(ControllerContext Context)
    		{
    			//Context.IsChildAction
    
    			if (Context == null)
    			{
    				throw new ArgumentNullException("Context");
    			}
    
    			JsonCallback = Context.HttpContext.Request["callback"];
    
    			if (string.IsNullOrEmpty(JsonCallback))
    			{
    				JsonCallback = Context.HttpContext.Request["jsoncallback"];
    			}
    
    			if (string.IsNullOrEmpty(JsonCallback))
    			{
    				throw new ArgumentNullException("JsonP callback parameter required for JsonP response.");
    			}
    
    			HttpResponseBase CurrentResponse = Context.HttpContext.Response;
    
    			if (!String.IsNullOrEmpty(ContentType))
    			{
    				CurrentResponse.ContentType = ContentType;
    			}
    			else
    			{
    				CurrentResponse.ContentType = "application/json";
    			}
    
    			if (ContentEncoding != null)
    			{
    				CurrentResponse.ContentEncoding = ContentEncoding;
    			}
    
    			if (Data != null)
    			{
    				CurrentResponse.Write(string.Format("{0}({1});", JsonCallback, _jser.Serialize(Data)));
    			}
    		}
    	}
    }
