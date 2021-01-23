    public class myClass
    {
      public myClass
      {
        GetMessageAsync.ContinueWith(GetResultAsync);
      }
    
      async Task<string> GetMessageAsync()
      {
        return await Service.GetMessageFromAPI(); 
      }
    private async Task GetResultAsync(Task<string> resultTask)
    {
        if (resultTask.IsFaulted)
    {
          Log(resultTask.Exception); 
    }
    eles
    {
     //do what ever you need from the result
    }
    }
    }
