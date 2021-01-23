    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        public static class Program
        {
            private static void Main()
            {
                var queue = new BlockingCollection<int[]>();
                Task.Factory.StartNew(() => produce(queue));
                consume(queue);
                Console.WriteLine("Finished.");
            }
            private static void consume(BlockingCollection<int[]> queue)
            {
                foreach (var item in queue.GetConsumingEnumerable())
                {
                    Console.WriteLine("Consuming " + item[0]);
                    Thread.Sleep(25);
                }
            }
            private static void produce(BlockingCollection<int[]> queue)
            {
                for (int i = 0; i < 1000; ++i)
                {
                    Console.WriteLine("Producing " + i);
                    var payload = new int[100];
                    payload[0] = i;
                    queue.Add(payload);
                    Thread.Sleep(20);
                }
                queue.CompleteAdding();
            }
        }
    }
