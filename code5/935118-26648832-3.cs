    var gatewayAddress = new IpAddress(IpProvider.BroadcastAddress);
    var udpClient = new UdpClient(gatewayAddress);
    await udpClient.SendAsync(data);
    Tuple<IpAddress, byte[]> message;
    while (udpClient.TryGetIncomingMessage(out message))
    {
        if (message.Item1.Address == IpProvider.LocalAddress)
        {
            continue;
        }
        HandleIncomingPacket(message);
    }
