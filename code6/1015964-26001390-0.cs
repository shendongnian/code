    static void Parse( params string[] list )
    {
      Parse( (IEnumerable<string> list ) ;
    }
    static void Parse( IEnumerable<T> list )
    {
      foreach( string s in list )
      {
        Parse(s) ;
      }
      return ;
    }
