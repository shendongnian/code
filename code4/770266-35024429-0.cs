       // Global.asax.cs file
       protected void Application_BeginRequest()
        {
            if (Request.IsLocal)
            {
                MiniProfiler.Start();
            }
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            MiniProfiler.Stop(discardResults: false);
        }
