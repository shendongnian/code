    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        public static class Program
        {
            private static void Main()
            {
                Console.WriteLine("Generating bids for 30 seconds...");
                using (var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30)))
                {
                    var task = GenerateBids(cancellationTokenSource.Token);
                    // You can do other work here as required.
                    task.Wait();
                }
                Console.WriteLine("\nTask finished.");
            }
            private static async Task GenerateBids(CancellationToken cancel)
            {
                while (!cancel.IsCancellationRequested)
                {
                    Console.WriteLine("");
                    try
                    {
                        for (int x = 0; x < 4; x++)
                            GenerateRandomBooking();
                        await Task.Delay(2000);
                        if (cancel.IsCancellationRequested)
                            return;
                        GenerateRandomBids();
                        AllocateBids();
                        await Task.Delay(2000);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            private static void AllocateBids()
            {
                Console.WriteLine("AllocateBids()");
            }
            private static void GenerateRandomBids()
            {
                Console.WriteLine("GenerateRandomBids()");
            }
            private static void GenerateRandomBooking()
            {
                Console.WriteLine("GenerateRandomBooking()");
            }
        }
    }
