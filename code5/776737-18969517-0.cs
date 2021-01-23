    class Program
    {
      static string TransformUserInput( string s )
      {
        if ( s == null ) throw new ArgumentNullException("s") ;
        string transformed = "" ;
        if ( s.Length > 0 )
        {
          transformed = rxLeadingZeros.Replace(s, m => m.Length == 0 ? "1" : m.Length == s.Length ? "0" : "" ) ;
        }
        return transformed ;
      }
      private static readonly Regex rxLeadingZeros = new Regex( @"^0*");
      
      static void Main( string[] args )
      {
        string [] values = { "" , "0" , "000" , "000000987654321000" , "54321000" , "0000000000000000000000000000000" , "000000000000000000009876543210" , } ;
        foreach ( string raw in values )
        {
          string cooked = TransformUserInput(raw) ;
          Console.WriteLine( "raw    : {0}",raw) ;
          Console.WriteLine( "cooked : {0}",cooked);
          Console.WriteLine() ;
        }
        return;
      }
    }
