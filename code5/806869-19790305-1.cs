    public class FrameworkTestBase: FrameworkBase
    {
      protected abstract Task ProcessRequestMessageAsync();
      protected override sealed async void ProcessRequestMessage()
      {
        try
        {
          await ProcessRequestMessageAsync();
          SetResponseCode(0);
        }
        catch
        {
          SetResponseCode(-1);
        }
      }
    }
