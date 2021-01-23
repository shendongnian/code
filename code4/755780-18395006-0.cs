    public static void Main()  {
      // Creates and initializes a new Array.
      Array myArray=Array.CreateInstance( typeof(String), 9 );
      myArray.SetValue( "The", 0 );
      myArray.SetValue( "quick", 1 );
      myArray.SetValue( "brown", 2 );
      myArray.SetValue( "fox", 3 );
      myArray.SetValue( "jumps", 4 );
      myArray.SetValue( "over", 5 );
      myArray.SetValue( "the", 6 );
      myArray.SetValue( "lazy", 7 );
      myArray.SetValue( "dog", 8 );
      // Displays the values of the Array.
      Console.WriteLine( "The Array initially contains the following values:" );
      PrintIndexAndValues( myArray );
      // Reverses the sort of the values of the Array.
      Array.Reverse( myArray );
      // Displays the values of the Array.
      Console.WriteLine( "After reversing:" );
      PrintIndexAndValues( myArray );
    }
    public static void PrintIndexAndValues( Array myArray )  {
      for ( int i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++ )
         Console.WriteLine( "\t[{0}]:\t{1}", i, myArray.GetValue( i ) );
    }
