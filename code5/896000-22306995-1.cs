    static int Main( string[] argv )
    {
      int cc ;
      try
      {
         ExecApplicationCore( argv ) ;
         cc = 0 ;
      }
      catch( Exception e )
      {
         ILog log = LogManager.GetLogger(this.GetType()) ;
         log.Fatal(e) ;
         cc = 1 ;
      }
      return cc ;
    }
