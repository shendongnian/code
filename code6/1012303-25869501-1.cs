     public static string FindIPAddress()
            {
                List<string> ipAddresses = new List<string>();
                var hostnames = NetworkInformation.GetHostNames();
                foreach (var hn in hostnames)
                {
                    //IanaInterfaceType == 71 => Wifi
                    //IanaInterfaceType == 6 => Ethernet (Emulator)
                    if (hn.IPInformation != null && 
                        (hn.IPInformation.NetworkAdapter.IanaInterfaceType == 71 
                        || hn.IPInformation.NetworkAdapter.IanaInterfaceType == 6))
                    {
                        string ipAddress = hn.DisplayName;
                        ipAddresses.Add(ipAddress);
                    }
                }
     
                if (ipAddresses.Count < 1)
                {
                    return null;
                }
                else if (ipAddresses.Count == 1)
                {
                    return ipAddresses[0];
                }
                else
                {
                    //if multiple suitable address were found use the last one
                    //(regularly the external interface of an emulated device)
                    return ipAddresses[ipAddresses.Count - 1];
                }
            }
