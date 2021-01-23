    static void Main( string[] args )
    {
      string[] texts         = { "2014-05-23T17:45:32.123" ,
                                 "2014-05-23T17:45:32.12"  ,
                                 "2014-05-23T17:45:32.1"   ,
                                 "2014-05-23T17:45:32"     ,
                                 "2014-05-23T17:45"        ,
                               } ;
      string[] utcDesignators = { ""  ,
                                  "Z"
                                } ;
      
      foreach ( string timeString in texts )
      {
        
        foreach ( string utc in utcDesignators )
        {
          string   timestamp = timeString+utc ;
          DateTime parsed    = ParseAsZuluTime(timestamp) ;
          
          Console.WriteLine() ;
          Console.WriteLine( "Text:     {0}" , timestamp  ) ;
          Console.WriteLine( "DateTime: {0:yyyy-MM-ddThh:mm:ss.fff}, Kind: {1}" , parsed , parsed.Kind ) ;
          
        }
      }
      Console.WriteLine() ;
      
      return;
    }
