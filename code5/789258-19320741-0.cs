    public static class ConsoleEx
    {
      public static bool TryReadKey(TimeSpan timeout, out ConsoleKeyInfo keyinfo)
      {
        var cts = new CancellationTokenSource();
        return TryReadKey(timeout, cts.Token, out keyinfo);
      }
     
      public static bool TryReadKey(TimeSpan timeout, CancellationToken cancellation, out ConsoleKeyInfo keyinfo)
      {
        keyinfo = new ConsoleKeyInfo();
        DateTime latest = DateTime.UtcNow.Add(timeout);
        do
        {
            cancellation.ThrowIfCancellationRequested();
            if (Console.KeyAvailable)
            {
                keyinfo = Console.ReadKey();
                return true;
            }
            Thread.Sleep(1);
        }
        while (DateTime.UtcNow < latest);
        return false;
      }
    }
