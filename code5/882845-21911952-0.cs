    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    class MyService
    {
       public void DivisionByZeroException()
       {
          int a = 0;
          int c = 1 / a;
       }
    }
