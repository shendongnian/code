    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common.Environment;
    using System.Threading;
    namespace HandleTesting
    {
        class Program
        {
            private static CancellationTokenSource static_cts = new CancellationTokenSource();
            static void Main(string[] args)
            {
                //Periodic.StartNew(() =>
                //{
                //    Console.WriteLine(string.Format("CPU_{0} Mem_{1} T_{2} H_{3} GDI_{4} USR_{5}",
                //        Performance.CPU_Percent_Load(),
                //        Performance.PrivateMemorySize64(),
                //        Performance.ThreadCount(),
                //        Performance.HandleCount(),
                //        Performance.GDI_Objects_Count(),
                //        Performance.USER_Objects_Count()));
                //}, 5);
                Action RunMethod;
                Console.WriteLine("Program Started...\r\n");
                var MainScope_cts = new CancellationTokenSource();
                do
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    try
                    {
                        var LoopScope_cts = new CancellationTokenSource();
                        Console.WriteLine("Enter number of Sleep.For() iterations:");
                        var Loops = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter millisecond interval per iteration:");
                        var Rate = int.Parse(Console.ReadLine());
                        RunMethod = () => SomeMethod(Loops, Rate, MainScope_cts.Token);
                        RunMethod();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine("\r\nPress any key to try again, or press Escape to exit.");
                }
                while (Console.ReadKey().Key != ConsoleKey.Escape);
                Console.WriteLine("\r\nProgram Ended...");
            }
            private static void SomeMethod(int p_loops, int p_rate, CancellationToken p_token)
            {
                var local_cts = new CancellationTokenSource();
                Console.WriteLine("Method Executing " + p_loops + " Loops at " + p_rate + "ms each.\r\n");
                for (int i = 0; i < p_loops; i++)
                {
                    var Handles = Performance.HandleCount();
                    Sleep.For(p_rate, p_token); /*<--- Change token here to test GC and variable Scoping*/
                    Console.WriteLine("H_pre " + Handles + ", H_post " + Performance.HandleCount());
                }
            }
        }
    }
