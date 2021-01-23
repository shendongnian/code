    // this is a service method
    void FooBar() {  
      try
      {
        // lets see whether we can divide by zero ...
        var a = 0;
        var b = 1/a;
        Console.Writeln("It works!!");
      }
      catch(e:TException)
      {
        throw; // Thrift exception, don't interfere
      }
      catch(e:Exception)
      {
         throw new TApplicationException( "WTF?");  // or some other exception
      }
    }
