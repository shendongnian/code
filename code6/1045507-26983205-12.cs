        static void Main(string[] args)
        {
            var task = Start();
            Task.Run(() =>
            {
                Thread.Sleep(500);
                Console.WriteLine("Starting GC");
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Console.WriteLine("GC Done");
            });
            Console.WriteLine(task.Result);
            Console.Read();
        }
        private static async Task<object> Start()
        {
            Console.WriteLine("Start");
            Synchronizer sync = new Synchronizer();
            await Task.Delay(Timeout.Infinite); 
            // OR: await new Task<object>(() => sync);
            // OR: await sync.SynchronizeAsync();
            return sync;
        }
