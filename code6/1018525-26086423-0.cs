    public static void Main()
    {
        Info myinfo = new Info();
        myinfo.DisplayInfo();
        //Assignment3.MathOperations.DisplayResults();
        //you need to create an instance of MathOperations before you can call the
        //non-static DisplayResults() method.
          MathOperations operation = new MathOperations();
        //capture your return value
          double result = operation.DisplayResults(someValue, someOtherValue);
          Console.WriteLine(result);
          Console.ReadLine();
    }
