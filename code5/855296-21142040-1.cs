    ManagementScope manScope = new ManagementScope(@"\\\\" + myServerName+ \\root\\virtualization");  
    ObjectQuery queryObj = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");
    ManagementObjectSearcher vmSearcher = new ManagementObjectSearcher(manScope, queryObj);
    
    foreach (ManagementObject ob in vmSearcher.Get())
    {
        txtPhysicalProcessors.Text = ob["NumberOfProcessors"].ToString();
        txtRam.Text = Convert.ToString(Math.Round(Convert.ToDouble(ob["TotalPhysicalMemory"].ToString()) / 1073741824, 1)) + " GB";
    }
