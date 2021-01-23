    public static string GetIPAddress()
    {
        var AllNetworkInterfaces = Collections.List(Java.Net.NetworkInterface.NetworkInterfaces);
        var IPAddres = "";
        foreach (var interfaces in AllNetworkInterfaces)
        {
            if (!(interfaces as Java.Net.NetworkInterface).Name.Contains("eth0")) continue;
            var AddressInterface = (interfaces as Java.Net.NetworkInterface).InterfaceAddresses;
            foreach (var AInterface in AddressInterface)
            {
                if(AInterface.Broadcast != null)
                    IPAddres = AInterface.Address.HostAddress;
            }
        }
            return IPAddres;
    }
