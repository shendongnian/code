    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        public class Program
        {
            private readonly BlockingCollection<string> _queue = new BlockingCollection<string>();
            private void run()
            {
                Task.Run(() => producer());
                consumer();
                Console.WriteLine("Press <return> to exit.");
            }
            private void consumer()
            {
                Console.WriteLine("consumer() starting.");
                foreach (var item in _queue.GetConsumingEnumerable())
                {
                    Console.WriteLine("consumer() processing item " + item);
                }
                Console.WriteLine("consumer() stopping.");
            }
            private void producer()
            {
                Console.WriteLine("producer() starting.");
                for (int i = 0; i < 20; ++i)
                {
                    _queue.Add(i.ToString());
                    Thread.Sleep(200);
                }
                Console.WriteLine("producer() finishing.");
            
                _queue.CompleteAdding(); // Calling this makes the consumer exit its foreach loop.
            }
            private static void Main(string[] args)
            {
                new Program().run();
            }
        }
    }
