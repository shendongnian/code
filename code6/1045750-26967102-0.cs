    public static double GetAppDomainCpuUsage(AppDomain hostDomain)
            {
                if (Process.GetCurrentProcess().TotalProcessorTime.TotalMilliseconds > 0)
                    return hostDomain.MonitoringTotalProcessorTime.TotalMilliseconds * 100 /                  Process.GetCurrentProcess().TotalProcessorTime.TotalMilliseconds;
                return 0;
            }
            public static double GetAppDomainMemoryUsage(AppDomain hostDomain)
            {
                if (AppDomain.MonitoringSurvivedProcessMemorySize > 0)
                    return (double)hostDomain.MonitoringSurvivedMemorySize * 100 / (double)AppDomain.MonitoringSurvivedProcessMemorySize;
                return 0;
            }
