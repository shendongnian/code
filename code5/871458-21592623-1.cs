    static void Main()
    {
      int   n      = ReadIntegerFromConsole( "How many values do you want to enter?" ) ;
      int[] values = new int[n] ;
      for ( int i = 0 ; i < values.Length ; ++i )
      {
        string prompt = string.Format( "{0}/{1}?" , i , n ) ;
        
        values[i] = ReadIntegerFromConsole(prompt) ;
        
      }
      
      Console.WriteLine( "You entered: {0}" , string.Join(", ",values) ) ;
      return ;
    }
    
    static int ReadIntegerFromConsole( string prompt )
    {
      int  value   ;
      bool isValid ;
      
      do
      {
        
        Console.Write( prompt) ;
        Console.Write( ' ' );
        
        string text = Console.ReadLine() ;
        
        isValid = int.TryParse(text, out value ) ;
        
        prompt = "That's not an integer. Try again:" ;
      } while (!isValid) ;
      
      return value ;
    }
