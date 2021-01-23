    private static async Task RunClient()
    {
        var client = new ChannelTcpClient<object>(
            new MicroMessageEncoder(new DataContractSerializer()),
            new MicroMessageDecoder(new DataContractSerializer())
            );
     
        await client.ConnectAsync(IPAddress.Parse("192.168.1.3"), 1234);
        await client.SendAsync(new DeviceCommand("turnoff"));
        await client.CloseAsync();
    }
