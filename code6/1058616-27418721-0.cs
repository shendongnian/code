    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                while (true)
                {
                    var bytesSentPerformanceCounter = new PerformanceCounter();
                    bytesSentPerformanceCounter.CategoryName = ".NET CLR Networking";
                    bytesSentPerformanceCounter.CounterName = "Bytes Sent";
                    bytesSentPerformanceCounter.InstanceName = GetInstanceName();
                    bytesSentPerformanceCounter.ReadOnly = true;
    
                    var bytesReceivedPerformanceCounter = new PerformanceCounter();
                    bytesReceivedPerformanceCounter.CategoryName = ".NET CLR Networking";
                    bytesReceivedPerformanceCounter.CounterName = "Bytes Received";
                    bytesReceivedPerformanceCounter.InstanceName = GetInstanceName();
                    bytesReceivedPerformanceCounter.ReadOnly = true;
    
                    Console.WriteLine("Bytes sent: {0}", bytesSentPerformanceCounter.RawValue);
                    Console.WriteLine("Bytes received: {0}", bytesReceivedPerformanceCounter.RawValue);
                    Thread.Sleep(1000);
                }
            }
    
            private static string GetInstanceName()
            {
                string returnvalue = "not found";
              //Checks bandwidth usage for CUPC.exe..Change it with your application Name
                string applicationName = "CUPC"; 
                    PerformanceCounterCategory[] Array = PerformanceCounterCategory.GetCategories();
                for (int i = 0; i < Array.Length; i++)
                {
                    if (Array[i].CategoryName.Contains(".NET CLR Networking"))
                        foreach (var item in Array[i].GetInstanceNames())
                        {
                            if (item.ToLower().Contains(applicationName.ToString().ToLower()))
                                returnvalue = item;
    
                        }
    
                }
                return returnvalue;
            }
        }
    }
