                ManagementScope scope = new ManagementScope();
                var options = new ConnectionOptions();
                options.Authentication = AuthenticationLevel.Default;
                options.Impersonation = ImpersonationLevel.Impersonate;
                options.EnablePrivileges = true;
    
                scope = new ManagementScope(@"\\" + machine + "\\root\\CIMV2", options);
                scope.Connect();
                SelectQuery query = new SelectQuery("Select * FROM Win32_NetworkAdapterConfiguration");
                ManagementObjectSearcher objMOS = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection objMOC = objMOS.Get();
                string macAddress = String.Empty;
                foreach (ManagementObject objMO in objMOC)
                {
                    object tempMacAddrObj = objMO["MacAddress"];
    
                    if (tempMacAddrObj == null)
                    {
                        continue;
                    }
                    if (macAddress == String.Empty)
                    {
                        macAddress = tempMacAddrObj.ToString();
                    }
                    objMO.Dispose();
                }
    
                return macAddress;
