    public string GetDiskNumber(string letter)
    {
        var ret = "0";
        var scope = new ManagementScope("\\\\.\\ROOT\\cimv2");
        var query = new ObjectQuery("Associators of {Win32_LogicalDisk.DeviceID='" +     letter + ":'} WHERE ResultRole=Antecedent");
        var searcher = new ManagementObjectSearcher(scope, query);
        var queryCollection = searcher.Get();
        foreach (ManagementObject m in queryCollection)
        {
            ret = m["Name"].ToString().Replace("Disk #", "")[0].ToString();
        }
        return ret;
    }
