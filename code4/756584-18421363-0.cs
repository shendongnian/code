    static void Main( string[] args )
    {
        NetworkInterface[] matches = NetworkInterface
            .GetAllNetworkInterfaces()
            .Where(i => 
                i.OperationalStatus == OperationalStatus.Up && (
                i.Name.Contains("Wireless Network Connection 2") ||
                i.Description.Contains("Microsoft Virtual WiFi Miniport Adapter")))
            .ToArray();
        foreach (var match in matches)
        {
            Console.WriteLine("Name\t\t: " + match.Name);
            Console.WriteLine("    Type\t\t: " + match.NetworkInterfaceType);
            Console.WriteLine("    Speed\t\t: " + match.Speed);
            Console.WriteLine("    Description\t: " + match.Description);
            UnicastIPAddressInformationCollection unicastIPC = match.GetIPProperties().UnicastAddresses;
            foreach (UnicastIPAddressInformation unicast in unicastIPC)
            {
                Console.WriteLine("    " + unicast.Address.AddressFamily + "\t: " + unicast.Address);
            }
        }
    }
