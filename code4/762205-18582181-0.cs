    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management;
    using System.Text;
    using System.Windows;
     public void getCOMportsValues()
        {
            try
            {
                if (COMports.Count > 0) COMports.Clear(); // COMports is a List<string>
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    string s = queryObj["Name"] as string;
                    if (s.Contains("(COM"))
                        COMports.Add(s);
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying WMI data: " + e.Message);
            }
        }
        
