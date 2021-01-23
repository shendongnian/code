    private static ILog log = log4net.LogManager.GetLogger( typeof(Global) ) ;
    
    void Application_BeginRequest( object sender , EventArgs e )
    {
      Stopwatch timer = new Stopwatch();
      timer.Start();
      Request.RequestContext.HttpContext.Items["timer"] = timer ;
      return ;
    }
    
    void Application_EndRequest( object sender , EventArgs e )
    {
      Stopwatch timer = (Stopwatch) this.Request.RequestContext.HttpContext.Items["timer"] ;
      timer.Stop() ;
      log.InfoFormat( "HttpVerb={0}, URL={1}, elapsed time={2}" ,
        this.Request.RequestType ,
        this.Request.Url ,
        timer
        ) ;
      return ;
    }
