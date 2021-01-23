    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        public class Program
        {
            private readonly BlockingCollection<int> _queue = new BlockingCollection<int>();
            private void run()
            {
                const int CONSUMER_COUNT = 8;
                Task[] tasks = new Task[CONSUMER_COUNT];
                for (int i = 0; i < CONSUMER_COUNT; ++i)
                {
                    int id = i;
                    tasks[i] = Task.Run(() => process(id));
                }
                Console.WriteLine("Press <return> to start adding to the queue.");
                Console.ReadLine();
                for (int i = 0; i < 100; ++i)
                {
                    Console.WriteLine("Adding item #{0}", i);
                    _queue.Add(i);
                }
                Console.WriteLine("Press <return> to close the queue.");
                Console.ReadLine();
                _queue.CompleteAdding();
                Console.WriteLine("Waiting for all tasks to exit.");
                Task.WaitAll(tasks);
                Console.WriteLine("Finished waiting for all tasks. Press <return> to exit.");
                Console.ReadLine();
            }
            private void process(int id)
            {
                Console.WriteLine("Process {0} is starting.", id);
                foreach (var item in _queue.GetConsumingEnumerable())
                {
                    Console.WriteLine("Process {0} is processing item# {1}", id, item);
                    Thread.Sleep(200); // Simulate long processing time.
                }
                Console.WriteLine("Process {0} is stopping.", id);
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }
