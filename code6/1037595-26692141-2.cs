    //Assembly A
    public struct SomeStruct
    {
       public int x = 0;
       internal SomeStruct()
       { 
           x = 10;
       }
    }
    
    public static void DoSomething()
    {
          var someStruct = new SomeStruct();
          Console.WriteLine(someStruct.x); // prints 10  
    }
    
    
    //Assembly B
    public static void DoAnotherThing()
    {
        var someStruct = new SomeStruct();
        Console.WriteLine(someStruct.x); // prints 0
    }
