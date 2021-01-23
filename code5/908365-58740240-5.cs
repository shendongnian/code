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
            /// Print the system TickCount (converted from Win32_OperatingSystem LocalDateTime - LastBootUpTime properties).
            /// Why? Because this technique can be used to get TickCount from a Remote machine.
            /// </summary>
            public static void Main(string[] args)
            {
                var tickCount = GetRemoteMachineTickCount("REMOTEMACHINENAME");
				
				if (!tickCount.HasValue)
                {
                    throw new NullReferenceException("GetRemoteMachineTickCount() response was null.");
                }
                Console.WriteLine("TickCount: {tickCount}");
                Console.ReadKey();
            }
            
            /// <summary>
            /// Retrieves the duration (TickCount) since the system was last started from a remote machine.
            /// </summary>
            /// <param name="computerName">Name of computer on network to retrieve tickcount for</param>
            /// <returns>WMI Win32_OperatingSystem LocalDateTime - LastBootUpTime (ticks)</returns>
            private static int? GetRemoteMachineTickCount(string computerName)
            {
                string namespaceName = @"root\cimv2";
                string queryDialect = "WQL";
                DComSessionOptions SessionOptions = new DComSessionOptions();
                SessionOptions.Impersonation = ImpersonationType.Impersonate;
                var baseLineTickCount = Environment.TickCount; // Note: to determine discrepancy
                CimSession session = CimSession.Create(computerName, SessionOptions);
                string query = "SELECT * FROM Win32_OperatingSystem";
                var cimInstances = session.QueryInstances(namespaceName, queryDialect, query);
                if (cimInstances.Any())
                {
                    var cimInstance = cimInstances.First();
                    var lastBootUpTime = Convert.ToDateTime(cimInstance.CimInstanceProperties["LastBootUpTime"].Value);
                    var localDateTime = Convert.ToDateTime(cimInstance.CimInstanceProperties["LocalDateTime"].Value);
                    var timeSpan = localDateTime - lastBootUpTime;
                    var tickCount = Convert.ToInt32(timeSpan.TotalMilliseconds);
                    var discrepancy = tickCount - baseLineTickCount; // Note: discrepancy about +/- 100 ticks
                    return tickCount;
                }
                return null;
            }
        }
    }
