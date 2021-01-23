    public interface ISomeService
    {
      bool DoSomething();
    }
    public class MyClass
    {
      private readonly ISomeService _someService;
      public MyClass(ISomeService someService)
      {
        _someService = someService;
      }
      public Task MyMethod()
      {
        return Task.Run(() =>
        {
          var success = _someService.DoSomething();
          if (!success) throw new Exception("unsuccsesfull");
        });
      }
    }
