    class Program
    {
        public static BufferBlock<int> m_Queue = new BufferBlock<int>(new DataflowBlockOptions { BoundedCapacity = 1000 });
        private static int evenNumber;
        static void Main(string[] args)
        {
            var producer = Producer();
            var consumer = Consumer();
            Task.WhenAll(producer, consumer).Wait();
            Report();
        }
        static void Report()
        {
            Console.WriteLine("There are {0} even numbers", evenNumber);
            Console.Read();
        }
        static async Task Producer()
        {
            for (int i = 0; i < 500; i++)
            {
                // Send a value to the consumer and wait for the value to be processed
                await m_Queue.SendAsync(i);
            }
            // Signal the consumer that there will be no more values
            m_Queue.Complete();
        }
        static async Task Consumer()
        {
            var executionDataflowBlockOptions = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = 4
            };
            var consumerBlock = new ActionBlock<int>(x =>
            {
                int j = DoWork(x);
                if (j % 2 == 0) 
                    // Increment the counter in a thread-safe way
                    Interlocked.Increment(ref evenNumber);
            }, executionDataflowBlockOptions);
            // Link the buffer to the consumer
            using (m_Queue.LinkTo(consumerBlock, new DataflowLinkOptions { PropagateCompletion = true }))
            {
                // Wait for the consumer to finish.
                // This method will exit after all the data from the buffer was processed.
                await consumerBlock.Completion;
            }
        }
        static int DoWork(int x)
        {
            Thread.Sleep(100);
            return x;
        }
    }
