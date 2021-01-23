        int coreCount = 0;
        foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
        {
            coreCount += int.Parse(item["NumberOfCores"].ToString());
        }
        PerformanceCounter[] pc = new PerformanceCounter[coreCount];
        for (int i = 0; i < coreCount; i++)
        {
            pc[i] = new PerformanceCounter("Processor", "% Processor Time", i.ToString());
            Console.WriteLine(pc[i].CounterName);
        }
