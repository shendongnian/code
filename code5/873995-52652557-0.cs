    public static string PerformanceCounterInstanceName(this Process process)
    {
        var matchesProcessId = new Func<string, bool>(instanceName =>
        {
            using (var pc = new PerformanceCounter("Process", "ID Process", instanceName, true))
            {
                if ((int)pc.RawValue == process.Id)
                {
                    return true;
                }
            }
            return false;
        });
        string processName = Path.GetFileNameWithoutExtension(process.ProcessName);
        return new PerformanceCounterCategory("Process")
           .GetInstanceNames()
           .AsParallel()
           .FirstOrDefault(instanceName => instanceName.StartsWith(processName)
                                           && matchesProcessId(instanceName));
    }
