    public static Task<bool> CommandAsync(this Link link, Commands command)
    {
      var tcs = new TaskCompletionSource<bool>();
      if (!link.Command(command, result => tcs.TrySetResult(result)))
          tcs.TrySetException(new ConnectionErrorException());
      return tcs.Task;
    }
