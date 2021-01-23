    public void RunMinecraftsServer()
    {
        try
        {
            ...
    
             var dtEndTime = DateTime.Now.AddMinutes( 1 );
             while ( !serverProc.HasExited && ( DateTime.Now < dtEndTime ) )
             {
                  System.Threading.Thread.Sleep( TimeSpan.FromMilliseconds( 500 ) );
                  serverProc.Refresh();
            }
        }
        catch ( Exception ex )
        {
           ...
        }
    }
