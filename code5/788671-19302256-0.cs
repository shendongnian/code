    protected void Application_BeginRequest(object sender, System.EventArgs e)
    {
        if(HttpContext.Current.Request.CurrentExecutionFilePathExtension == ".aspx"){
             //stuff to do
        }
    }
