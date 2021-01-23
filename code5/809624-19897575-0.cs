    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest()
        {
            if (String.IsNullOrEmpty(Context.Request.ContentType) && Context.Request.HttpMethod == "POST")
            {
                Context.Request.ContentType = "application/x-www-form-urlencoded";
            }
        }
        protected void Application_EndRequest()
        {
            Context.Response.AddHeader("Access-Control-Allow-Origin", "*");
        }
    }
