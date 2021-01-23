    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        internal class Program
        {
            private void run()
            {
                Task.Run(new Action(producer));
                Task.Run(new Action(consumer));
                while (!_empty.WaitOne(1000))
                    Console.WriteLine("Waiting for queue to empty");
                Console.WriteLine("Queue emptied.");
            }
            private void producer()
            {
                for (int i = 0; i < 20; ++i)
                {
                    _queue.Add(i);
                    Console.WriteLine("Produced " + i);
                    Thread.Sleep(100);
                }
                _queue.CompleteAdding();
            }
            private void consumer()
            {
                foreach (int n in _queue.GetConsumingEnumerable())
                {
                    Console.WriteLine("Consumed " + n);
                    Thread.Sleep(200);
                }
                _empty.Set();
            }
            private static void Main()
            {
                new Program().run();
            }
            private BlockingCollection<int> _queue = new BlockingCollection<int>();
            private ManualResetEvent _empty = new ManualResetEvent(false);
        }
    }
