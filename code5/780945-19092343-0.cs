    static void Main()
    {
        Console.WriteLine("start");
        try
        {
            AggregateException innerException = null;
            Task.Factory.StartNew(PrintTime, CancellationToken.None)
                        .ContinueWith(t => innerException = t.Exception, TaskContinuationOptions.OnlyOnFaulted);
            for (int i = 0; i < 20; i++)
            {
                if (innerException != null)
                    throw innerException;
                Console.WriteLine("master thread i={0}", i + 1);
                Thread.Sleep(1000);
            }
        }
        catch (AggregateException)
        {
            Console.WriteLine("Inner thread caused exception. Main thread handles that exception.");
        }
    }
