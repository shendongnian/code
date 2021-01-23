    public class Global : HttpApplication
    {
     
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Context.Items.Remove("AfterPageUnloaded");
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var pageUnloaded = Context.Items.Contains("AfterPageUnloaded") && (bool)Context.Items["AfterPageUnloaded"];
            if (pageUnloaded)
            {
                //Your code goes here..
                Context.Items.Remove("AfterPageUnloaded");
            }
        }
    }
