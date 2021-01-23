    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    namespace Demo
    {
        public static class Program
        {
            private static void Main()
            {
                var queue = new BufferBlock<int[]>();
                Task.Factory.StartNew(() => produce(queue));
                consume(queue).Wait();
                Console.WriteLine("Finished.");
            }
            private static async Task consume(BufferBlock<int[]> queue)
            {
                while (await queue.OutputAvailableAsync())
                {
                    var payload = await queue.ReceiveAsync();
                    Console.WriteLine("Consuming " + payload[0]);
                    await Task.Delay(25);
                }
            }
            private static void produce(BufferBlock<int[]> queue)
            {
                for (int i = 0; i < 1000; ++i)
                {
                    Console.WriteLine("Producing " + i);
                    var payload = new int[100];
                    payload[0] = i;
                    queue.Post(payload);
                    Thread.Sleep(20);
                }
                queue.Complete();
            }
        }
    }
