    class RequestController
    {
      private FooClass fooClass;
      public RequestController(ref FooClass fooClass)
      {
        this.fooClass = fooClass;
      }
      public async void OnResponseReceived()
      {
        try
        {
          await fooClass.ProcessingRequest();
        }
        catch (Exception ex)
        {
          System.Diagnostics.Debug.Fail(ex.Message);
        }
      }
    }
    public class FooClass
    {
      private object myObj;
      public async Task ProcessingRequest()
      {
        await myObj.MethodAsync(id, type, RequestFailedCB, myObj);
      }
    }
