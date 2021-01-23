    private static void PrintLocalAddresses()
    {
        var interfaces = NetworkInterface.GetAllNetworkInterfaces();
        foreach (var ni in interfaces)
        {
            if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
            {
                var adapterProperties = ni.GetIPProperties();
                foreach (var x in adapterProperties.UnicastAddresses)
                {
                    if (x.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        Console.WriteLine(x.Address);
                    }
                }
            }
        }
    }
