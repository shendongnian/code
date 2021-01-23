    public static class NetworkConfigurator
    {
        /// <summary>
        /// Set's a new IP Address and it's Submask of the local machine
        /// </summary>
        /// <param name="ipAddress">The IP Address</param>
        /// <param name="subnetMasks">The Submask IP Address</param>
        /// <param name="gateway">The gateway.</param>
        /// <remarks>Requires a reference to the System.Management namespace</remarks>
        public static bool SetIPs(string sourceMacAddress,string[] ipAddresses, string[] subnetMasks, string gateway=null)
        {
            UInt32 res;
            
            using (var networkConfigMng = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                using (var networkConfigs = networkConfigMng.GetInstances())
                {                    
                    using(var managementObject=networkConfigs.Cast<ManagementObject>()
                                                        .Where(instance =>
                                                                 ((string)instance["MACAddress"])!=null)
                                                        .FirstOrDefault(instance =>
                                                                 ((string)instance["MACAddress"]).Replace(":", "")==sourceMacAddress) )
                    {
                        if (managementObject == null)
                            return false;
                        using (var newIPs = managementObject.GetMethodParameters("EnableStatic"))
                        {
                            if (ipAddresses==null || 
                                ipAddresses.Length==0 || 
                                subnetMasks==null || 
                                subnetMasks.Length!=ipAddresses.Length)
                                return false;
                                    newIPs["IPAddress"] = ipAddresses;// new[] { ipAddress };
                                    newIPs["SubnetMask"] = subnetMasks;
                                 res = (UInt32) (managementObject.InvokeMethod("EnableStatic", newIPs, null).GetPropertyValue("returnValue"));
                                if (res != 0)
                                    return false;
                            
                            // Set mew gateway if needed
                            if (!String.IsNullOrEmpty(gateway))
                            {
                                using (var newGateway = managementObject.GetMethodParameters("SetGateways"))
                                {
                                    newGateway["DefaultIPGateway"] = new[] { newGateway };
                                    newGateway["GatewayCostMetric"] = new[] { 1 };
                                    res=(UInt32)(managementObject.InvokeMethod("SetGateways", newGateway, null).GetPropertyValue("returnValue"));
                                    if (res != 0)
                                        return false;
                                }
                            }
                            return true;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Set's the DNS Server of the local machine
        /// </summary>
        /// <param name="nic">NIC address</param>
        /// <param name="dnsServers">Comma seperated list of DNS server addresses</param>
        /// <remarks>Requires a reference to the System.Management namespace</remarks>
        public static void SetNameservers(string nic, string dnsServers)
        {
            using (var networkConfigMng = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                using (var networkConfigs = networkConfigMng.GetInstances())
                {
                    foreach (var managementObject in networkConfigs.Cast<ManagementObject>().Where(objMO => (bool)objMO["IPEnabled"] && objMO["Caption"].Equals(nic)))
                    {
                        using (var newDNS = managementObject.GetMethodParameters("SetDNSServerSearchOrder"))
                        {
                            newDNS["DNSServerSearchOrder"] = dnsServers.Split(',');
                            managementObject.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                        }
                    }
                }
            }
        }
    }
 
