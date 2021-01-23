    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    namespace Demo
    {
        public sealed class ProducerConsumerQueue<T>: IEnumerable<T>
        {
            /// <summary>Has the queue been closed?</summary>
            public bool IsClosed
            {
                get
                {
                    return _isClosed;
                }
            }
            /// <summary>The object used to synchronize access to the queue.</summary>
            public object SyncLock
            {
                get
                {
                    return _syncLock;
                }
            }
            /// <summary>Tell the queue that no more items will be added.</summary>
            /// <param name="waitUntilEmpty">Wait until the queue is empty before returning?</param>
            public void Close(bool waitUntilEmpty)
            {
                lock (_syncLock)
                {
                    _isClosed = true;
                    Monitor.PulseAll(_syncLock);     // Wake up all consumers.
                    if (waitUntilEmpty)
                    {
                        while (_queue.Count > 0)
                        {
                            Monitor.Wait(_syncLock);
                        }
                    }
                }
            }
            /// <summary>Adds an item the the queue.</summary>
            /// <param name="item">The item to be added.</param>
            public void Add(T item)
            {
                lock (_syncLock)
                {
                    if (_isClosed)
                    {
                        throw new InvalidOperationException("The queue has been closed.");
                    }
                    _queue.Enqueue(item);
                    if (_queue.Count == 1)
                    {
                        Monitor.Pulse(_syncLock);    // Added first item to the queue; wake up a consumer.
                    }
                }
            }
            /// <summary>Typesafe Enumerator access to the queue items.</summary>
            public IEnumerator<T> GetEnumerator()
            {
                while (true)
                {
                    T item;
                    lock (_syncLock)
                    {
                        if (_queue.Count > 0)
                        {
                            item = _queue.Dequeue();
                            if (_isClosed && (_queue.Count == 0))
                            {
                                Monitor.PulseAll(_syncLock);    // Tell producer we're done.
                            }
                        }
                        else if (_isClosed)
                        {
                            yield break;                // All done.
                        }
                        else
                        {
                            Monitor.Wait(_syncLock);    // Waits for another item to enter the queue or the queue to be closed.
                            continue;                   // Back to "while".
                        }
                    }
                    yield return item;  // Yield outside of the lock.
                }
            }
            /// <summary>Non-typesafe Enumerator access to the queue items.</summary>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            private readonly Queue<T> _queue = new Queue<T>();
            private readonly object _syncLock = new object();
            private bool _isClosed;
        }
        public static class Program
        {
            private static void Main()
            {
                ProducerConsumerQueue<string> queue = new ProducerConsumerQueue<string>();
                // Spawn first consumer thread.
                ThreadPool.QueueUserWorkItem
                (
                    delegate
                    {
                        foreach (string item in queue)
                        {
                            Console.WriteLine("Consumer 1 is consuming: " + item);
                            randomSleep(200); // simulate business
                        }
                        Console.WriteLine("Consumer 1 exited cleanly.");
                    }
                );
                // Spawn second consumer thread.
                ThreadPool.QueueUserWorkItem
                (
                    delegate
                    {
                        foreach (string item in queue)
                        {
                            Console.WriteLine("Consumer 2 is consuming: " + item);
                            randomSleep(250); // simulate business
                        }
                        Console.WriteLine("Consumer 2 exited cleanly.");
                    }
                );
                // Spawn third consumer thread.
                ThreadPool.QueueUserWorkItem
                (
                    delegate
                    {
                        foreach (string item in queue)
                        {
                            Console.WriteLine("Consumer 3 is consuming: " + item);
                            randomSleep(300); // simulate business
                        }
                        Console.WriteLine("Consumer 3 exited cleanly.");
                    }
                );
                // Spawn first producer thread.
                ThreadPool.QueueUserWorkItem
                (
                    delegate
                    {
                        for (int i = 0;; i++)
                        {
                            lock (queue.SyncLock)
                            {
                                if (!queue.IsClosed)
                                {
                                    string item = "Producer 1 Item " + i.ToString();
                                    Console.WriteLine("Producer 1 is adding: " + item);
                                    queue.Add(item);
                                }
                            }
                            if (i < 50)     // Slowly add the first 50.
                            {
                                randomSleep(500); // simulate business
                            }
                            else            // Quickly add the remainder to get a backlog.
                            {
                                randomSleep(150); // simulate business
                            }
                        }
                    }
                );
                // Spawn second producer thread.
                ThreadPool.QueueUserWorkItem
                (
                    delegate
                    {
                        for (int i = 0;; i++)
                        {
                            lock (queue.SyncLock)
                            {
                                if (!queue.IsClosed)
                                {
                                    string item = "Producer 2 Item " + i.ToString();
                                    Console.WriteLine("Producer 2 is adding: " + item);
                                    queue.Add(item);
                                }
                            }
                            if (i < 50)     // Slowly add the first 50.
                            {
                                randomSleep(600); // simulate business
                            }
                            else            // Quickly add the remainder to get a backlog.
                            {
                                randomSleep(120); // simulate business
                            }
                        }
                    }
                );
                Thread.Sleep(20000);                        // Allow a few seconds for things to happen.
                Console.WriteLine("Closing queue...");
                queue.Close(true);
                Thread.Sleep(1000);
                Console.WriteLine("Press [return] to exit");
                Console.ReadLine();
            }
            private static void randomSleep(int max)
            {
                int delay;
                lock (_random)
                {
                    delay = _random.Next(max + 100);
                }
                if (delay > 100)
                {
                    Thread.Sleep(delay-100);
                }
            }
            static readonly Random _random = new Random();
        }
    }
