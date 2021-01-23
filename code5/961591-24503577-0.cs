    [InterceptAspect]
    class TestImpl : ITest
      {
        public void Call()
        {
          Console.WriteLine("CALL remote implemented");
        }
      }
