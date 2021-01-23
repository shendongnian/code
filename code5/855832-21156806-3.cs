    using System;
    using System.Web;
    
    public class Globalizer : IHttpModule
    {    
      public void Init(HttpApplication context)
      {
        context.AcquireRequestState += new EventHandler(setLanguage);
      }
    
      public void Dispose(){}
    
      public void setLanguage(Object sender, EventArgs i_eventArgs)
      {
        if(HttpContext.Current.Session != null){
          HttpContext.Current.Session["language"] = "test";
        }
    
      }
    }
 
