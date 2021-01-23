    public class FrameworkTestBase: FrameworkBase
    {
      protected abstract Task ProcessRequestMessageAsync();
      protected override sealed void ProcessRequestMessage()
      {
        ProcessRequestMessageAsync().ContinueWith(t =>
        {
          if (t.IsFaulted || t.IsCanceled)
            SetResponseCode(-1);
          else
            SetResponseCode(0);
        });
      }
    }
    public class MyClass: FrameworkBase
    {
      protected override async Task ProcessRequestMessageAsync()
      {
        //await something
      }
    }
