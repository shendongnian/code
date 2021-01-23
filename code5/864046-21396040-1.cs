        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (HttpContext.Current.IsDebuggingEnabled)
            {
                HttpContext.Current.Session["user"] = "1";
            }
            else
            {
                HttpContext.Current.Session["user"] = "0";
            } 
        }
