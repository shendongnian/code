    private string GetDriveLabel(DriveInfo drv)
    {
        string drvName;
        string drvLabel;
        string pvdr = "";
    
        //Start off with just the drive letter
        drvName = "(" + drv.Name.Substring(0,2) + ")";
    
        //Use the volume label if it is not a network drive
        if (drv.DriveType != DriveType.Network)
        {
            drvLabel = drv.VolumeLabel;
            return drvLabel + " " + drvName;
        }
    
        //Try to get the network share name            
        try
        {
            var searcher = new ManagementObjectSearcher(
                "root\\CIMV2",
                "SELECT * FROM Win32_MappedLogicalDisk WHERE Name=\"" + drv.Name.Substring(0,2) + "\"");
    
            foreach (ManagementObject queryObj in searcher.Get())
            {
                pvdr = @queryObj["ProviderName"].ToString();
            }
        }
        catch (ManagementException ex)
        {
            pvdr = "";
        }
    
        //Try to get custom label from registry
        if (pvdr != "")
        {   
            pvdr = pvdr.Replace(@"\", "#");
            drvLabel = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\MountPoints2\" + pvdr, "_LabelFromReg", "");
            if (string.IsNullOrEmpty(drvLabel))
            {
                //If we didn't get the label from the registry, then extract the share name from the provider
                drvLabel = pvdr.Substring(pvdr.LastIndexOf("#") + 1);
            }
            return drvLabel + " " + drvName;
        }
        else
        {
            //No point in trying the registry if we don't have a provider name
            return drvName;
        }
    }
