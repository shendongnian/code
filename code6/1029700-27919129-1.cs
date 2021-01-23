                // The WMI query 
                const string QueryString = "SELECT * FROM Win32_PnPSignedDriver ";
                SelectQuery WMIquery = new SelectQuery(QueryString);
                ManagementObjectSearcher WMIqueryResults = new ManagementObjectSearcher(WMIquery);
                // Make sure results were found
                if (WMIqueryResults == null)
                    return;
                // Scan query results to find port
                ManagementObjectCollection MOC = WMIqueryResults.Get();
                foreach (ManagementObject mo in MOC)
                { 
                    if (mo["FriendlyName"] != null && mo["FriendlyName"].ToString().Contains("YOUR_DEVICE_NAME"))
                    {}
                  //Check the mo Properties to find the COM port
                }
    
