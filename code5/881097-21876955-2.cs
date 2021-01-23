    public static class Extensions
    {
      public static Task<Stream> GetRequestStreamAsync(this WebRequest webRequest)
      {
        TaskCompletionSource<Stream> taskComplete = new TaskCompletionSource<Stream>();
        webRequest.BeginGetRequestStream(arg =>
        {
            try
            {
                Stream requestStream = webRequest.EndGetRequestStream(arg);
                taskComplete.TrySetResult(requestStream);
            }
            catch (Exception ex) { taskComplete.SetException(ex); }
        }, webRequest);
        return taskComplete.Task;
      }
    }
