    public static void Test1(int errorCode) {
      if (errorCode > 0) {
        Console.WriteLine(errorCode);
        return;
      }
      Console.WriteLine("ok");
    }
    
    public static void Test2(int errorCode) {
      if (errorCode > 0) {
        Console.WriteLine(errorCode);
      } else {
        Console.WriteLine("ok");
      }
    }
