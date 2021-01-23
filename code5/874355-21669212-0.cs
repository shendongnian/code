    using System;
    using System.Web;
    
    namespace WebApplication1
    {
        public class Global : HttpApplication
        {
    	  protected void Application_BeginRequest(object sender, EventArgs e)
      	  {
    	    // Get request.
    	    HttpRequest request = base.Request;
    
    	    // Get UserHostAddress property.
    	    string address = request.UserHostAddress;
    
    	    // Write to response.
    	    base.Response.Write(address);
    
    	    // Done.
    	    base.CompleteRequest();
    	  }
        }
    }
