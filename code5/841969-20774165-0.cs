    class MyClass { 
      public void ListInts(params int[] inVals ) {
        if (Object.ReferenceEquals(null, inVals))
          return;
    
        foreach(int item in inVals)  
          Console.WriteLine("{0}", item * 10);
      }
    }
