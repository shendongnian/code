    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using StackExchange.Redis;
    
    static class Program
    {
        static void Main()
        {
            using (var conn = ConnectionMultiplexer.Connect("localhost"))
            {
                var sub = conn.GetSubscriber();
                var received = new List<int>();
                Console.WriteLine("Subscribing...");
                const int COUNT = 500;
                sub.Subscribe("foo", (channel, message) =>
                {
                    lock (received)
                    {
                        received.Add((int)message);
                        if (received.Count == COUNT)
                            Monitor.PulseAll(received); // wake the test rig
                    }
                    Thread.Sleep(5); // you kinda need to be slow, otherwise
                    // the pool will end up doing everything on one thread
                });
                SendAndCheck(conn, received, COUNT, true);
                SendAndCheck(conn, received, COUNT, false);
            }
    
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
        static void SendAndCheck(ConnectionMultiplexer conn, List<int> received, int quantity, bool preserveAsyncOrder)
        {
            conn.PreserveAsyncOrder = preserveAsyncOrder;
            var sub = conn.GetSubscriber();
            Console.WriteLine();
            Console.WriteLine("Sending ({0})...", (preserveAsyncOrder ? "preserved order" : "any order"));
            lock (received)
            {
                received.Clear();
                // we'll also use received as a wait-detection mechanism; sneaky
    
                // note: this does not do any cheating;
                // it all goes to the server and back
                for (int i = 0; i < quantity; i++)
                {
                    sub.Publish("foo", i);
                }
    
                Console.WriteLine("Allowing time for delivery etc...");
                var watch = Stopwatch.StartNew();
                if (!Monitor.Wait(received, 10000))
                {
                    Console.WriteLine("Timed out; expect less data");
                }
                watch.Stop();
                Console.WriteLine("Checking...");
                lock (received)
                {
                    Console.WriteLine("Received: {0} in {1}ms", received.Count, watch.ElapsedMilliseconds);
                    int wrongOrder = 0;
                    for (int i = 0; i < Math.Min(quantity, received.Count); i++)
                    {
                        if (received[i] != i) wrongOrder++;
                    }
                    Console.WriteLine("Out of order: " + wrongOrder);
                }
            }
        }
    }
