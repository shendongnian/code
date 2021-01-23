    using System;
    using System.Diagnostics;
    using System.Threading;
    namespace ProcessSample
    {
        class ProcessMonitorSample
        {
            public static void Main()
            {
                Console.BufferHeight = 25;
                // Define variables to track the peak memory usage of the process. 
                long peakWorkingSet = 0;
                string[] Programs = System.IO.File.ReadAllLines(@"C:\Programs\list.txt");
                foreach (string Program in Programs)
                {
                    Process myProcess = null;
                    // Start the process.
                    myProcess = Process.Start(@Program);
                    Console.WriteLine("Program started: {0}", Program);
                }
            }
        }
    }
