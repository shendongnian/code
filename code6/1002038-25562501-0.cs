    class Program
    {
        private static SemaphoreSlim semaphore = new SemaphoreSlim(2, 2);
        public static async Task CreateSPFolder(int folder)
        {
            try
            {
                await semaphore.WaitAsync();
                Console.WriteLine("Executing " + folder);
                Console.WriteLine("WaitAsync - CurrentCount " + semaphore.CurrentCount);
                await Task.Delay(2000);
            }
            finally
            {
                Console.WriteLine("Finished Executing " + folder);
                semaphore.Release();
                Console.WriteLine("Release - CurrentCount " + semaphore.CurrentCount);
            }
            var rand = new Random();
            var next = rand.Next(10);
            var children = Enumerable.Range(1, next).ToList();
            Task.WaitAll(children.Select(CreateSPFolder).ToArray());            
        }
        static void Main(string[] args)
        {
            CreateSPFolder(1).Wait();
            Console.ReadKey();
        }
    }
