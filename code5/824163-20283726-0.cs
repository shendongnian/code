    public class Global : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = base.Context;
            HttpRequest request = context.Request;
            string pageName = System.IO.Path.GetFileNameWithoutExtension(request.RawUrl);
            if (pageName != "YourPageName")
            {
                if(context.Session["NameOfSessionVariable"] != null)
                    context.Session.Remove("NameOfSessionVariable");
            }
        }
    }
