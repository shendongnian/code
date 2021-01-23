    static string NetworkGateway()
    {
        string ip = null;
        foreach (NetworkInterface f in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (f.OperationalStatus == OperationalStatus.Up)
            {
                foreach (GatewayIPAddressInformation d in f.GetIPProperties().GatewayAddresses)
                {
                    ip = d.Address.ToString();
                }
            }
        }
        Console.WriteLine(string.Format("Network Gateway: {0}", ip));
        return ip;
    }
