    public static char[,] CreateCharArray( int rows , int cols )
    {
      const string charset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" ; // whatever character set you want here
      if ( rows < 1 || cols < 1 ) throw new ArgumentException();
      
      // create and populate the initial set of pairs
      char[] chars = new char[rows*cols];
      for ( int i = 0 ; i < chars.Length ; )
      {
        char ch = charset[ rng.Next(charset.Length) ] ;
        chars[i++] = ch ;
        chars[i++] = ch ;
      }
      
      // shuffle it up
      Shuffle(chars) ;
      // construct the 2-D grid
      char[,] grid = new char[rows,cols];
      for ( int i = 0 , k = 0 ; i < rows ; ++i )
      {
        for ( int j = 0 ; j < cols ; ++j )
        {
          grid[i,j] = chars[k++] ;
        }
      }
      
      return grid ;
    }
    private static Random rng = new Random() ;
    
    private static void Shuffle( char[] chars)
    {
      for ( int i = chars.Length ; --i >= 0 ; )
      {
        int j    = rng.Next(i) ;
        char t   = chars[j] ;
        chars[j] = chars[i] ;
        chars[i] = t        ;
      }
      return ;
    }
