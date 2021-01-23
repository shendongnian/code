            string query = string.Format("SELECT * FROM Win32_Printer")
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection coll = searcher.Get();
            string name = "";
            foreach (ManagementObject printer in coll)
            {
                foreach (PropertyData property in printer.Properties)
                {
                    if (property.Name == "Name")
                    {
                        name = property.Value.ToString();
                    }
                    rtxLog.AppendText(property.Name + "-->" + property.Value + "\n");
                    if (property.Name == "WorkOffline")
                    {
                        string querydriver = string.Format("SELECT * from Win32_PrinterDriver WHERE Name LIKE '%" + name + "%'");
                        ManagementObjectSearcher searcherdriver = new ManagementObjectSearcher(querydriver);
                        ManagementObjectCollection colldriver = searcherdriver.Get();
                        foreach (ManagementObject driver in colldriver)
                        {
                            foreach (PropertyData propertydriver in driver.Properties)
                            {
                                rtxLog.AppendText(propertydriver.Name + "-->" + propertydriver.Value + "\n");
                            }
                        }
                    }
                    rtxNameLog.AppendText(name + "\n");
                }
                rtxLog.AppendText("\n\n\n\n\n\n\n\n\n\n\n");
            }
