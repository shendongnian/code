    public static class ClientExtension
    {
      public static async Task<bool> ExecuteQueryAsync(this ClientContext ctx)
      {
         TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
         ctx.ExecuteQueryAsync(
            (s, e) => t.SetResult(true),
            (s, e) => t.SetException(e.Exception));
         return tcs.Task;
      }
    }
