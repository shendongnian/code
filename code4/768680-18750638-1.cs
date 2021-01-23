        private static BlockingCollection<string> _itemsToProcess = new BlockingCollection<string>();
        static void Main(string[] args)
        {
            InsertWorker();
            GenerateItems(10, 1000);
            _itemsToProcess.CompleteAdding();
        }
        private static void InsertWorker()
        {
            Task.Factory.StartNew(() =>
            {
                while (!_itemsToProcess.IsCompleted)
                {
                    string t;
                    if (_itemsToProcess.TryTake(out t))
                    {
                        // Do whatever needs doing here
                        // Order should be guaranteed since BlockingCollection 
                        // uses a ConcurrentQueue as a backing store by default.
                        // http://msdn.microsoft.com/en-us/library/dd287184.aspx#remarksToggle
                        Console.WriteLine(t);
                    }
                }
            });
        }
        private static void GenerateItems(int count, int maxDelayInMs)
        {
            Random r = new Random();
            string[] items = new string[count];
            for (int i = 0; i < count; i++)
            {
                items[i] = i.ToString();
            }
            // Simulate many threads adding items to the collection
            items
                .AsParallel()
                .WithDegreeOfParallelism(4)
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .Select((x) =>
                {
                    Thread.Sleep(r.Next(maxDelayInMs));
                    _itemsToProcess.Add(x);
                    return x;
                }).ToList();
        }
