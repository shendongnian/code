    public class Global : HttpApplication
    {
     
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Context.Items.Remove("PageUnloaded");
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var pageUnloaded = Context.Items.Contains("PageUnloaded") && (bool)Context.Items["PageUnloaded"];
            if (pageUnloaded)
            {
                //Your code goes here..
                Context.Items.Remove("PageUnloaded");
            }
        }
    }
