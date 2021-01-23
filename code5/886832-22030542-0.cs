    string serverIP = drpServer.SelectedItem.Value.ToString();
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"\\" + serverIP + "\\root\\CIMV2", "SELECT * FROM Win32_PerfFormattedData_PerfProc_Process");
    DataTable dt = new DataTable();
    dt.Columns.Add("ProcessName", typeof(string));
    dt.Columns.Add("ProcessID", typeof(int));
    dt.Columns.Add("CPUTime", typeof(string));
    dt.Columns.Add("MemoryUsage", typeof(string));
    foreach (ManagementObject query in searcher.Get())
    {   
        var processName = query["Name"];
        var processID = query["IDProcess"];
        var cpuTime = query["PercentProcessorTime"];
        var memUsage = query["WorkingSet"];
        double newMemUsage = Convert.ToDouble(memUsage);
        newMemUsage = newMemUsage / 1024;
        DataRow row = dt.NewRow();
        row["ProcessName"] = processName;
        row["ProcessID"] = processID;
        row["CPUTime"] = cpuTime;
        row["MemoryUsage"] = newMemUsage;
        dt.Rows.Add(row);
    }
    GridView1.DataSource = dt;
    GridView1.DataBind();
