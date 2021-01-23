        var searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
        var cpuUsages = searcher.Get()
            .Cast<ManagementObject>()
            .Select(x => new
                          {
                              Name = x["Name"],
                              Usage = x["PercentProcessorTime"]
                          }
            )
            .ToList();
        var totalUsage = cpuUsages.Where(x => x.Name.ToString() == "_Total").Select(x => x.Usage).SingleOrDefault();
