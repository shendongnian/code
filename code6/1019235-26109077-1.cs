    static int Main( string[] args )
    {
      Console.WriteLine("Press an arrow key." ) ;
      Console.Write("? " ) ;
      foreach ( ConsoleKey key in ReadKeyStrokes() )
      {
        Console.WriteLine( "You pressed {0}" , key ) ;
        Console.Write("? ") ;
      }
      return 0 ;
    }
