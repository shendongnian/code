    var connectionName = "Ethernet Adapter Local Area Connection";
    var connection =
        NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(
            ni => ni.Name == connectionName);
    if (connection != null)
    {
        Console.WriteLine("Connection \"{0}\" found.", connectionName);
    
        // Use a regex to focus on the IPv4 address and ignore the IPv6 address if
        // present.
        var ipV4Regex = new Regex("(?<IPv4Address>([0-9]{1,3}\\.){3}[0-9]{1,3})");
        var unicastAddresses = connection.GetIPProperties().UnicastAddresses;
        var ipV4Address =
            unicastAddresses.FirstOrDefault(
                ua => ipV4Regex.Match(ua.Address.ToString()).Success);
    
        if (ipV4Address != null)
            Console.WriteLine("IPv4 address {0} found.", ipV4Address.Address);
        else
            Console.WriteLine("IPv4 address not found.");
    }
    else
    {
        Console.WriteLine("Connection \"{0}\" not found.", connectionName);
    }
