    public static uint GetProcessMemoryUsageInKilobytes(string processName)
    {
        var performanceCounter = 
            new PerformanceCounter("Process", "Working Set", processName);
        return (uint)performanceCounter.NextValue() / 1024;
    }
