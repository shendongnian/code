    class RandomLicensePlateNumberGenerator
    {
      static readonly Random Randomizer = new Random() ;
      
      public string Generate( string pattern )
      {
        if ( string.IsNullOrWhiteSpace(pattern)) throw new ArgumentOutOfRangeException("pattern") ;
          return new string( pattern.Select( RandomCharacter ).ToArray() ) ;
      }
      
      public IEnumerable<string> Stream( string pattern )
      {
        while ( true )
        {
          yield return Generate( pattern ) ;
        }
      }
      
      public char RandomCharacter( char c )
      {
        char value ;
        lock ( Randomizer )
        {
          switch ( c )
          {
          case 'A' : case 'a' : value = (char) Randomizer.Next( 'A' , 'Z' + 1 ) ; break ;
          case '#' : case '9' : value = (char) Randomizer.Next( '0' , '9' + 1 ) ; break ;
          default  :            value = c                                       ; break ;
          }
        }
        return value ;
      }
      
    }
    class Program
    {
      static void Main()
      {
        RandomLicensePlateNumberGenerator licensePlates = new RandomLicensePlateNumberGenerator();
        int i = 0 ;
        foreach ( string s in licensePlates.Stream( "AAA-999" ).Take(1000) )
        {
          Console.WriteLine( "{0,6:#,##0}: {1}",++i,s) ;
        }
        return ;
      }
    }
