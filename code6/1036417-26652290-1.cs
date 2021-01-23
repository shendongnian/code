    private static string GetLocalAddress()
    {
        var hostnames = NetworkInformation.GetHostNames();
        foreach (var hn in hostnames)
        {
            //IanaInterfaceType == 71 => Wifi
            //IanaInterfaceType == 6 => Ethernet (Emulator)
            if (hn.IPInformation != null &&
                (hn.IPInformation.NetworkAdapter.IanaInterfaceType == 71
                 || hn.IPInformation.NetworkAdapter.IanaInterfaceType == 6))
            {
                return hn.DisplayName;
            }
        }
        return IpAddress.Broadcast.Address;
    }
