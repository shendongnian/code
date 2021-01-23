    public static SystemUser GetSystemUser( object o )
    {
      SystemUser instance ;
      if ( o is string )
      {
        instance = GetSystemUser( (string) o ) ;
      }
      else
      {
        instance = (SystemUser) o ;
      }
      return instance ;
    }
    public static SystemUser GetSystemUser( string s )
    {
      return (SystemUser) s ;
    }
