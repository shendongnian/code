        {
            var sb = new StringBuilder();
            NetworkInterface[] networkInterfaces =
                NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface network in networkInterfaces)
            {
                IPInterfaceProperties properties = network.GetIPProperties();
                foreach (UnicastIPAddressInformation address in
                    properties.UnicastAddresses)
                {
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)  // We're only interested in IPv4 addresses for now 
                        continue;
                    if (IPAddress.IsLoopback(address.Address))  // Ignore loopback addresses (e.g., 127.0.0.1) 
                        continue;
                    if (network.OperationalStatus == OperationalStatus.Up)
                        sb.AppendLine(address.Address.ToString() + " (" + network.Name + ")");
                }
            }
            Console.WriteLine(sb.ToString());
        }
