    public void GetProcessOwner(int processId)
    {
        string query = "SELECT * FROM Win32_Process WHERE ProcessId = " + processId;
        using (var searcher = new ManagementObjectSearcher("root\\CIMV2", query))
        {
            foreach (var queryObj in searcher.Get().OfType<ManagementObject>())
            {
                ManagementBaseObject outParams = queryObj.InvokeMethod("GetOwner", null, null);
                Console.WriteLine("{0} is owned by {1}\\{2}", queryObj["Name"], outParams["Domain"], outParams["User"]);
            }
        }
     }
