    private Task<IEnumerable<YourDataItem>> CallWebServiceAsync()
    {
      var tcs = new TaskCompletionSource();
      var service = new YourServiceClient();
      service.SomeOperationCompleted +=
        (sender, args) =>
        {
          if (args.Error == null)
          {
            tcs.SetResult(args.Result);
          }
          else
          {
            tcs.SetException(args.Error);
          }
        };
      service.SomeOperationAsync();
      return tcs.Task;
    }
