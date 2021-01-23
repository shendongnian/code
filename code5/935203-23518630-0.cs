    private static int _count;
    static void Main(string[] args)
    {
      ...
        for (int i = 0; i < symbols.Result.Count(); i++)
        {
          if (i < symbols.Result.Count())
          {
            string symbol = symbols.Result.ElementAtOrDefault(i);
            Task t = Task.Run(() => getCalculationsDataWithCountAsync(symbol, "amex"));
            tasks.Add(t);
          }
        }
      ...
    }
    public static async Task getCalculationsDataWithCountAsync(string symbol, string market)
    {
      Console.WriteLine(Interlocked.Increment(ref _count) + " threads are running.");
      try
      {
        await getCalculationsDataAsync(symbol, market);
      }
      finally
      {
        Console.WriteLine(Interlocked.Decrement(ref _count) + " threads are running.");
      }
    }
