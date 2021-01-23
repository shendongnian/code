     public static void ExecuteRequest()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.google.com");
            request.ServicePoint.BindIPEndPointDelegate = new BindIPEndPoint(BindIPEndPointCallback);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }
        private static IPEndPoint BindIPEndPointCallback(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
        {
            // We want to make sure we try everything for the request to pass.
            IPEndPoint defaultEndPoint = null;
            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Loop through all interfaces, check if the current interface is 'Up' (ready to transmit) first.
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    bool returnIP = false;
                    //if (networkInterface.Id == "MyAdapter")
                    //if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                    {
                        // If the interface matches our wishes, tell the next block of code to return the (if) found matching IP
                        returnIP = true;
                    }
                    if (returnIP || defaultEndPoint == null)
                    {
                        // Loop through the UnicastAddresses assigned to this interface.
                        foreach (UnicastIPAddressInformation ip in networkInterface.GetIPProperties().UnicastAddresses)
                        {
                            // Check if any of the addresses is IPv4
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                // If so, create ourselves a new IPEndPoint and if needed return it.
                                defaultEndPoint = new IPEndPoint(ip.Address, 0);
                                if (returnIP)
                                {
                                    return defaultEndPoint;
                                }
                            }
                        }
                    }
                }
            }
            if (defaultEndPoint == null)
            {
                // Optional:
                //throw new NotSupportedException("A valid internet connection is required for this program to run.");
            }
            return defaultEndPoint;    
        }
