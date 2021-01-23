     System.Management.ManagementScope objMS = 
            new System.Management.ManagementScope(ManagementPath.DefaultPath);
        objMS.Connect();
    
        SelectQuery objQuery = new SelectQuery("SELECT * FROM Win32_Printer");
        ManagementObjectSearcher objMOS = new ManagementObjectSearcher(objMS, objQuery);
        System.Management.ManagementObjectCollection objMOC = objMOS.Get();
        foreach (ManagementObject Printers in objMOC)
        {
            if (Convert.ToBoolean(Printers["Local"]))       // LOCAL PRINTERS.
            {
                cmbLocalPrinters.Items.Add(Printers["Name"]);
            }
            if (Convert.ToBoolean(Printers["Network"]))     // ALL NETWORK PRINTERS.
            {
                cmbNetworkPrinters.Items.Add(Printers["Name"]);
            }
        }
    }
