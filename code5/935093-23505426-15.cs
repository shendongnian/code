    public static class TaskExt
    {
        public static async void Observe(
            this Task @this,
            bool continueOnCapturedContext = true)
        {
            await @this.ConfigureAwait(continueOnCapturedContext);
        } 
    }
    static void Main(string[] args)
    {
        TaskScheduler.UnobservedTaskException += Handler;
        AppDomain.CurrentDomain.UnhandledException += Handler;
        Task.Run(() => { throw new ApplicationException("I'll throw an unhanded exception"); })
            .Observe();
        Task.Factory.StartNew(() => { throw new ApplicationException("I'll throw an unhanded exception too"); })
            .Observe();
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("I think everything is just peachy!");
        System.Threading.Thread.Sleep(10000);
    }
