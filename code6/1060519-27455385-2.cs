    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }
        static async Task MainAsync()
        {
            TestClass tceOn = new TestClass();
            Stopwatch s = Stopwatch.StartNew();
            s.Checkpoint("Before sync on");
            tceOn.Execute();
            s.Checkpoint("After sync on");
            s.Checkpoint("Before async on");
            Task<Foo> fooTask = tceOn.ExecuteAsync();
            s.Checkpoint("After async on");
            Foo foo = await fooTask;
            s.Checkpoint("Awaited async on");
        }
    }
