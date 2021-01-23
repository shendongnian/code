    public static class ProducerConsumer
    {
        public static ConcurrentQueue<String> SqsQueue = new ConcurrentQueue<String>();         
        public static BlockingCollection<String> Collection = new BlockingCollection<String>();
        public static ConcurrentBag<String> Result = new ConcurrentBag<String>();
        public static async Task TestMethod()
        {
            // Here we separate all the Tasks in distinct threads
            Task sqs = Task.Run(async () =>
            {
                Console.WriteLine("Amazon on thread " + Thread.CurrentThread.ManagedThreadId.ToString());
                while (true)
                {
                    ProducerConsumer.BackgroundFakedAmazon(); // We produce 50 Strings each second
                    await Task.Delay(1000);
                }
            });
            Task deq = Task.Run(async () =>
            {
                Console.WriteLine("Dequeue on thread " + Thread.CurrentThread.ManagedThreadId.ToString());
                while (true)
                {
                    ProducerConsumer.DequeueData(); // Dequeue 20 Strings each 100ms 
                    await Task.Delay(100);
                }
            });
            Task process = Task.Run(() =>
            {
                Console.WriteLine("Process on thread " + Thread.CurrentThread.ManagedThreadId.ToString());
                ProducerConsumer.BackgroundParallelConsumer(); // Process all the Strings in the BlockingCollection
            });
            await Task.WhenAll(c, sqs, deq, process);
        }
        public static void DequeueData()
        {
            foreach (var i in Enumerable.Range(0, 20))
            {
                String dequeued = null;
                if (SqsQueue.TryDequeue(out dequeued))
                {
                    Collection.Add(dequeued);
                    Console.WriteLine("Dequeued : " + dequeued);
                }
            }
        }
        public static void BackgroundFakedAmazon()
        {
            Console.WriteLine(" ---------- Generate 50 items on amazon side  ---------- ");
            foreach (var data in Enumerable.Range(0, 50).Select(i => Path.GetRandomFileName().Split('.').FirstOrDefault()))
                SqsQueue.Enqueue(data + " / ASQS");
        }
        public static void BackgroundParallelConsumer()
        {
            // Here we stay in Parallel.ForEach, waiting for data. Once processed, we are still waiting the next chunks
            Parallel.ForEach(Collection.GetConsumingEnumerable(), (i) =>
            {
                // Processing Logic
                String processedData = "Processed : " + i;
                Result.Add(processedData);
                Console.WriteLine(processedData);
            });
        }
    }
