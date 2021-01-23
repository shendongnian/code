    using Microsoft.SqlServer.Server;
    
    class MySqlServerDotNetFunctions
    {
      [SqlFunction( TableDefinition="id int not null , value varchar(2000)" , FillRowMethodName="FillRow")]
      public static IEnumerable<Tuple<long,StringBuilder>> GenerateStrings( int stringLength )
      {
        const char lowerBound  = '!' ;
        const char upperBound = '~' ;
        if ( stringLength < 1 || stringLength > 2000 ) throw new ArgumentOutOfRangeException("stringLength","string length must be in the range 1-2000" ) ;
        
        // initialize the stringbuilder
        bool          carry = false ; // carry flag
        StringBuilder sb    = new StringBuilder(new string(lowerBound,stringLength)) ;
        for ( long i = 0 ; !carry && ++i > 0 ; )
        {
          // return the current iteration
          yield return new Tuple<long,StringBuilder>(i,sb) ;
          
          // increment our string
          int  p     = sb.Length-1 ; // we work right-to-left
          do
          {
            carry = ++sb[p] > upperBound   ;
            if ( carry )
            {
              sb[p] = lowerBound ;
            }
          } while ( carry && --p >= 0 ) ;
          
        }
      }
      
      public static void FillRow( object o , out long id , out string value )
      {
        Tuple<long,StringBuilder> item = (Tuple<long,StringBuilder>) o ;
        
        id    = item.Item1            ;
        value = item.Item2.ToString() ;
        return ;
      }
      
    }
