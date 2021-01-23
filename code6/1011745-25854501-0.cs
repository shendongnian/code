    public enum EndOfLineStyle
    {
      Unknown = 0     ,
      CR      = 1     ,
      LF      = 2     ,
      CRLF    = CR|LF ,
      Unix    = LF    ,
      MacOs   = CR    ,
      Windows = CRLF  ,
    }
    
    const int BUFFER_SIZE = 8192 ;
    public EndOfLineStyle DetermineEndOfLineStyle( string pathToFile )
    {
      int    bufl  = 0 ;
      char[] buf   = new char[BUFFER_SIZE] ;
      
      using ( StreamReader reader = File.OpenText( pathToFile ) )
      {
        bufl = reader.ReadBlock( buf , 0 , buf.Length ) ;
      }
      
      int crlfs = 0 ;
      int crs   = 0 ;
      int lfs   = 0 ;
      
      for ( int i = 0 ; i < bufl ; )
      {
        if      ( buf[i] == '\r' && i < bufl-1 && buf[i+1] == '\n' ) { ++crlfs ; i+=2 ; }
        else if ( buf[i] == '\r'                                   ) { ++crs   ; i+=1 ; }
        else if ( buf[i] == '\n' )                                   { ++lfs   ; i+=1 ; }
      }
      
      EndOfLineStyle style ;
      if      ( crlfs > crs   && crlfs > lfs ) style = EndOfLineStyle.Windows ;
      else if ( lfs   > crlfs && lfs   > crs ) style = EndOfLineStyle.Unix    ;
      else if ( crs   > crlfs && crs   > lfs ) style = EndOfLineStyle.MacOs   ;
      else                                     style = EndOfLineStyle.Unknown ;
      
      return style ;
    }
