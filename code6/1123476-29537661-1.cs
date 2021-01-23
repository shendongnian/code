    public List<String> GetLocalCOMDevices()
            {
                List<String> list = new List<String>();
    
                ManagementScope scope = new ManagementScope(@"\\" + Environment.MachineName + @"\root\CIMV2");
                SelectQuery sq = new SelectQuery("SELECT Name,Caption FROM Win32_PnPEntity");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, sq);
                ManagementObjectCollection moc = searcher.Get();
    
                foreach (ManagementObject mo in moc)
                {
                    object propName = mo.Properties["Name"].Value;
                    if (propName == null) { continue; }
    
                    list.Add(propName.ToString());
                }
                return list;
            }
