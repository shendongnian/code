    void foo(int[] array)
    {
      array[0] = 5;
    }
    
    void bar(int[] array)
    {
      array = new int[5];
      array[0] = 6;
    }
    
    void barWithRef(ref int[] array)
    {
      array = new int[6];
      array[0] = 6;
    }
    
    
    void Main()
    {
      int[] array = int[5];
      array[0] = 1;
    
      // First, lets call the foo() function.
      // This does exactly as you would expect... it will
      // change the first element to 5.
      foo(array);
    
      Console.WriteLine(array[0]); // yields 5
    
      // Now lets call the bar() function.
      // This will change the array in bar(), but not here.
      bar(array);
    
      Console.WriteLine(array[0]); // yields 1.  The array we have here was never changed.
    
      // Finally, lets use the ref keyword.
      barWithRef(ref array);
    
      Console.WriteLine(array[0]); // yields 5.  And the array's length is now 6.
    }
