        using System.Threading;
        using System.Threading.Tasks;
        CancellationTokenSource cts;
        public void Run()
        {
            cts = new CancellationTokenSource();
            var task = new Task(DoSomething, cts.Token);
            task.Start();
            while (!task.IsCompleted)
            {
                var keyInput = Console.ReadKey(true);
                if (keyInput.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Escape was pressed, cancelling...");
                    cts.Cancel();
                }
            }
            Console.WriteLine("Done.");
        }
        void DoSomething()
        {
            var count = 0;
            while (!cts.IsCancellationRequested)
            {
                Thread.Sleep(1000);
                count++;
                Console.WriteLine("Background task has ticked ({0}).", count.ToString());
            }
        }
