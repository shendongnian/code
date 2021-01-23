    public class Global : HttpApplication
    {
     
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Context.Items.Remove("PageUnloaded");
            Context.Items["loadstarttime"] = DateTime.Now;
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var pageUnloaded = Context.Items.Contains("PageUnloaded") && (bool)Context.Items["PageUnloaded"];
            DateTime end = (DateTime)Context.Items["loadstarttime"];
            TimeSpan loadtime = DateTime.Now - end;
            if (pageUnloaded)
            {
                //Your code goes here..
                Context.Items.Remove("PageUnloaded");
            }
        }
    }
