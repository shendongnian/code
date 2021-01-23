    static void Main(string[] args)
    {
        var task = TestSomethingAsync();
        Console.WriteLine("Press enter to GC");
        Console.ReadLine();
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
        GC.WaitForFullGCComplete();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Press enter to exit");
        Console.ReadLine();
    }
    static async Task TestSomethingAsync()
    {
        using (var something = new SomeDisposable())
        {
            await something.WaitForThingAsync();
        }
    }
    class SomeDisposable : IDisposable
    {
        readonly TaskCompletionSource<string> _tcs = new TaskCompletionSource<string>();
        ~SomeDisposable()
        {
            Console.WriteLine("~SomeDisposable");
        }
        public Task<string> WaitForThingAsync()
        {
            return _tcs.Task;
        }
        public void Dispose()
        {
            Console.WriteLine("SomeDisposable.Dispose");
            GC.SuppressFinalize(this);
        }
    }
