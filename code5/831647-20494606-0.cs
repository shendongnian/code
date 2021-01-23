    private bool isStarted;
    
    protected void Application_Start(object sender, EventArgs e)
    {
        this.isStarted = false;
    }
     
    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        if (!isStarted)
        {
             this.isStarted = true;
    
             if (Request.IsLocal) 
             {
                  MiniProfiler.Start();   
             }
        }
    }
    
    protected void Application_EndRequest(object sender, EventArgs e)
    {
         MiniProfiler.Stop();
    }
