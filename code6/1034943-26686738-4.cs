    using System.Management;
    
    ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
    foreach (ManagementObject mo in mos.Get())
    {
        Debug.Print(mo["Name"].ToString() + "," + mo["InstallLocation"].ToString() + Environment.NewLine);
    }
  
