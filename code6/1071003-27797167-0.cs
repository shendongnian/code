    public void ListNetworkProfiles()
    {
        NetworkCollection nCollection = NetworkListManager.GetNetworks(NetworkConnectivityLevels.All);
        foreach (Network net in nCollection)
        {
            Console.WriteLine("Name: " + net.Name + " Status: " + (net.IsConnected ? "Connected" : "Not Connected"));
        }
    }
