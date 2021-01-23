     protected void Application_EndRequest(Object sender,EventArgs e) 
                                                 
      { 
         HttpContext context = HttpContext.Current;
         if (context.Response.Status.Substring(0,3).Equals("401"))
         {
            context.Response.ClearContent();
             //do redirect here 
         } 
      }
