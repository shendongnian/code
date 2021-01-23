    public class MyClass
    {
      private static readonly ILog log = new MyLoggerWrapper(typeof(MyClass));
      public void DoSomething()
      {
        log.Info("Hello world!");
      }
    }
