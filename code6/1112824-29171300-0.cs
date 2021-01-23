    protected void Application_BeginRequest(object sender, EventArgs e)
    {
         if(Request.RequestContext.HttpContext.Request.ContentType.Equals("text/xml"))
         {
              Request.RequestContext.HttpContext.Request.ContentType = "text/xml; charset=UTF-8";
         }
    }
