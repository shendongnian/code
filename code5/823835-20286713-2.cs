    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    namespace SimpleProducerConsumer
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Main thread id is {0}.", Thread.CurrentThread.ManagedThreadId);
                using (var blockingCollection = new BlockingCollection<Action>())
                {
                    // Start our processing loop.
                    var actionLoop = new Thread(() =>
                    {
                        Console.WriteLine(
                            "Starting action loop on thread {0} (dedicated action loop thread).",
                            Thread.CurrentThread.ManagedThreadId,
                            Thread.CurrentThread.IsThreadPoolThread);
                        // Dequeue actions as they become available.
                        foreach (var action in blockingCollection.GetConsumingEnumerable())
                        {
                            // Invoke the action synchronously
                            // on the "actionLoop" thread.
                            action();
                        }
                        Console.WriteLine("Action loop terminating.");
                    });
                    actionLoop.Start();
                    // Enqueue some work.
                    Console.WriteLine("Enqueueing action 1 from thread {0} (main thread).", Thread.CurrentThread.ManagedThreadId);
                    blockingCollection.Add(() => SimulateWork(1));
                    Console.WriteLine("Enqueueing action 2 from thread {0} (main thread).", Thread.CurrentThread.ManagedThreadId);
                    blockingCollection.Add(() => SimulateWork(2));
                    // Let's enqueue it from another thread just for fun.
                    var enqueueTask = Task.Factory.StartNew(() =>
                    {
                        Console.WriteLine(
                            "Enqueueing action 3 from thread {0} (task executing on a thread pool thread).",
                            Thread.CurrentThread.ManagedThreadId);
                        blockingCollection.Add(() => SimulateWork(3));
                    });
                    // We have to wait for the task to complete
                    // because otherwise we'll end up calling
                    // CompleteAdding before our background task
                    // has had the chance to enqueue action #3.
                    enqueueTask.Wait();
                    // Tell our loop (and, consequently, the "actionLoop" thread)
                    // to terminate when it's done processing pending actions.
                    blockingCollection.CompleteAdding();
                    Console.WriteLine("Done enqueueing work. Waiting for the loop to complete.");
                    // Block until the "actionLoop" thread terminates.
                    actionLoop.Join();
                    Console.WriteLine("Done. Press Enter to quit.");
                    Console.ReadLine();
                }
            }
            private static void SimulateWork(int actionNo)
            {
                Thread.Sleep(500);
                Console.WriteLine("Finished processing action {0} on thread {1} (dedicated action loop thread).", actionNo, Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
