    class Program
    {
      static void Main(string[] args)
      {
        var dll = Assembly.LoadFile(@"C:\Test.dll");//The path of your dll
        var theType = dll.GetType("Test.Main()");
        var c = Activator.CreateInstance(theType);
        var method = theType.GetMethod("Output");//Your method in the class
        method.Invoke(c, new object[]{@"Hello world"});
        Console.ReadLine();
      }
    }
