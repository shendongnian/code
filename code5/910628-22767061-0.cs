    public static bool IsServerOS()
    {
        return IsServerOS(Environment.MachineName);
    }
    public static bool IsServerOS(string computerName)
    {
        ConnectionOptions options = new ConnectionOptions() { EnablePrivileges = true, Impersonation = ImpersonationLevel.Impersonate };
        ManagementScope scope = new ManagementScope(string.Format(@"\\{0}\root\CIMV2", computerName), options);
        ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
        using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
        using (ManagementObjectCollection results = searcher.Get())
        {
            if (results.Count != 1) throw new ManagementException();
            uint productType = (uint)results.OfType<ManagementObject>().First().Properties["ProductType"].Value;
            switch (productType)
            {
                case 1:
                    return false;
                case 2:
                    return true;
                case 3:
                    return true;
                default:
                    throw new ManagementException();
            }
        }
    }
