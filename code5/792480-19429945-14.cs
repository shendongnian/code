    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Management;
    using Common.Extensions;
    using System.Diagnostics;
    namespace Common.Environment
    {
        public static partial class Performance
        {
            //https://stackoverflow.com/a/9543180/1718702
            [DllImport("User32")]
            extern public static int GetGuiResources(IntPtr hProcess, int uiFlags);
            public static int GDI_Objects_Count()
            {
                //Return the count of GDI objects.
                return GetGuiResources(System.Diagnostics.Process.GetCurrentProcess().Handle, 0);
            }
            public static int USER_Objects_Count()
            {
                //Return the count of USER objects.
                return GetGuiResources(System.Diagnostics.Process.GetCurrentProcess().Handle, 1);
            }
            public static string CPU_Percent_Load()
            {
                //http://allen-conway-dotnet.blogspot.ca/2013/07/get-cpu-usage-across-all-cores-in-c.html
                //Get CPU usage values using a WMI query
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor");
                var cpuTimes = searcher.Get()
                    .Cast<ManagementObject>()
                    .Select(mo =>
                        new
                        {
                            Name = mo["Name"],
                            Usage = mo["PercentProcessorTime"]
                        }
                    ).ToList();
                var Total = cpuTimes[cpuTimes.Count - 1];
                cpuTimes.RemoveAt(cpuTimes.Count - 1);
                var PercentUsage = string.Join("_", cpuTimes.Select(x => Convert.ToInt32(x.Usage).ToString("00")));
                return PercentUsage + "," + Convert.ToInt32(Total.Usage).ToString("00");
            }
            public static long PrivateMemorySize64()
            {
                using (var P = Process.GetCurrentProcess())
                {
                    return P.PrivateMemorySize64;
                }
            }
            public static int ThreadCount()
            {
                using (var P = Process.GetCurrentProcess())
                {
                    return P.Threads.Count;
                }
            }
            public static int HandleCount()
            {
                using (var P = Process.GetCurrentProcess())
                {
                    return P.HandleCount;
                }
            }
        }
    }
