    public delegate object MyDelegate(string args = "123");
    private static object DoSomething(string args = "124")
    {
      Console.WriteLine(args); // prints "123"
      return null;
    }
