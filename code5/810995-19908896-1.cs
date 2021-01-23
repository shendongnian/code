    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            private void run()
            {
                using (var tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30)))
                {
                    var task = Task.Run(() => exampleOne(tokenSource.Token));
                    task.Wait();
                }
                using (var tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30)))
                {
                    var task = Task.Run(() => exampleTwo(tokenSource.Token));
                    task.Wait();
                }
                Console.WriteLine("Done.");
            }
            static void exampleZero()
            {
                Console.WriteLine("Starting exampleZero()");
                try
                {
                    Thread.Sleep(10000); // Simulate work.
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Operation cancelled.");
                }
                Console.WriteLine("Exiting exampleZero()");
            }
            static void exampleOne(CancellationToken cancellation)
            {
                Console.WriteLine("Starting exampleOne()");
                // Busy loop processing.
                while (!cancellation.IsCancellationRequested)
                {
                    // Do some work.
                }
                Console.WriteLine("Exiting exampleOne()");
            }
            static void exampleTwo(CancellationToken cancellation)
            {
                Console.WriteLine("Starting exampleTwo()");
                while (!cancellation.WaitHandle.WaitOne(100)) // Wait 100ms between work.
                {
                    // Do some work.
                }
                Console.WriteLine("Exiting exampleTwo()");
            }
            static void Main()
            {
                new Program().run();
            }
        }
    }
