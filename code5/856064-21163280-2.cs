    private static SemaphoreSlim semaphore = new SemaphoreSlim(1);
    private async static void DoSomethingAsync()
    {
         await semaphore.WaitAsync();
         try
         {
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
