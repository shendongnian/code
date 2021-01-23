    public class MyClass
    {
      private readonly Task task;
      public MyClass(Task task) { this.task = task ?? Task.FromResult(0); }
      public async Task ExecuteAsync()
      {
        await task;
      }
    }
