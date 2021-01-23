    using Microsoft.Management.Infrastructure;
    using Microsoft.Management.Infrastructure.Options;
    using System;
    using System.Linq;
    using System.Security;
    namespace TickCountTest
    {
        class Program
        {
            /// <summary>
            /// Print the system TickCount (converted from Win32_OperatingSystem LastBootUpTime property).
            /// Why? Because this technique can be used to get TickCount from a Remote machine.
            /// <summary>
            public static void Main(string[] args)
            {
                var lastBootUpTime = GetLastBootUpTime();
                
                if (!lastBootUpTime.HasValue)
                {
                    throw new NullReferenceException("GetLastBootUpTime() response was null.");
                }
                var tickCount = GetSystemUptimeTickCount(lastBootUpTime.Value);
                Console.WriteLine("TickCount: {tickCount}");
                Console.ReadKey();
            }
            
            /// <summary>
            /// Retrieves the time when the system was last started.
            /// </summary>
            /// <returns>WMI Win32_OperatingSystem LastBootUpTime property</returns>
            private static DateTime? GetLastBootUpTime()
            {
                string computer = "MYCOMPUTERNAME";
                string namespaceName = @"root\cimv2";
                string queryDialect = "WQL";
                string query = "SELECT * FROM Win32_OperatingSystem";
                DComSessionOptions SessionOptions = new DComSessionOptions();
                SessionOptions.Impersonation = ImpersonationType.Impersonate;
                CimSession session = CimSession.Create(computer, SessionOptions);
                var cimInstances = session.QueryInstances(namespaceName, queryDialect, query);
                if (cimInstances.Any())
                {
                    var lastBootUpTime = cimInstances.First().CimInstanceProperties["LastBootUpTime"].Value;
                    return Convert.ToDateTime(lastBootUpTime);
                }
                return null;
            }
            
            /// <summary>
            /// Converts LastBootUpTime (DateTime) to TickCount (int).
            /// Note: difference between this conversion and TickCount is between 1 and 12 milliseconds
            /// </summary>
            /// <param name="lastBootUpTime">Pass in WMI Win32_OperatingSystem LastBootUpTime property</param>
            /// <returns>Number of milliseconds that have elapsed since the system was started (from a DateTime)</returns>
            private static int GetSystemUptimeTickCount(DateTime lastBootUpTime)
            {
                var systemUpTime = DateTime.Now - lastBootUpTime;
                var tickCount = Convert.ToInt32(systemUpTime.TotalMilliseconds);
                var discrepancy = tickCount - Environment.TickCount; // between about 1 and 12 ms
                return tickCount;
            }
        }
    }
