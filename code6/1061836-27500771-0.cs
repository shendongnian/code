    System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher("SELECT NetConnectionStatus FROM Win32_NetworkAdapter");
    foreach (System.Management.ManagementObject networkAdapter in searcher.Get())
    {
        if (networkAdapter["NetConnectionStatus"] != null)
        {
            if (Convert.ToInt32(networkAdapter["NetConnectionStatus"]).Equals(2))
            {
                connected = true;
                break;
            }
        }
    }
