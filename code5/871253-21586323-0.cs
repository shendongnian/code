    string s = "ABCD1234" ;
    char   c = 'C' ;
    
    int offset = s.IndexOf(c) ;
    bool found = index >= 0 ;
    if ( !found )
    {
      Console.WriteLine( "string '{0}' does not contain char '{1}'" , s , c ) ;
    }
    else
    {
      string prefix = s.Substring(0,offset) ;
      string suffix = s.Substring(offset+1) ;
      
      Console.WriteLine( "char '{0}' found at offset +{1} in string '{2}'." , c , offset , s ) ;
      Console.WriteLine( "The substring before it is '{0}'."             , prefix ) ;
      Console.WriteLine( "The substring following it is '{0}'."          , suffix ) ;
      
    }
