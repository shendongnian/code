    private static SemaphoreSlim semaphore = new SemaphoreSlim(1);
    private async static void DoSomethingAsync()
    {
         try
         {
            await semaphore.WaitAsync();
            await Task.Factory.StartNew(() =>
            {
                Console.WriteLine("start");
                Thread.Sleep(5000);
                Console.WriteLine("end");
            });
         }
         finally
         {
            semaphore.Release();
         }
    }
    private static void Main(string[] args)
    {
        DoSomethingAsync();
        DoSomethingAsync();
        Console.Read();
    }
