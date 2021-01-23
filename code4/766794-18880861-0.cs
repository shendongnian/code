    private const string SSDP_IP = "239.255.255.250";
    private const string SSDP_PORT = "1900";
    public async static void DiscoverAsync2()
    {       
        var multicastIP = new HostName(SSDP_IP);
        var found = false;
        using (var socket = new DatagramSocket())
        {
            socket.MessageReceived += (sender, e) =>
            {
                var reader = e.GetDataReader();
                var bytesRemaining = reader.UnconsumedBufferLength;
                var receivedString = reader.ReadString(bytesRemaining);
                // TODO: something useful with this new info
                found = true;
            };
            await socket.BindEndpointAsync(null, string.Empty);
            socket.JoinMulticastGroup(multicastIP);
            while (true)
            { 
                found = false;
                using (var stream = await socket.GetOutputStreamAsync(multicastIP, SSDP_PORT))
                {
                    var request = new StringBuilder();
                    request.AppendLine("M-SEARCH * HTTP/1.1");
                    request.AppendLine("HOST: " + SSDP_IP + ":" + SSDP_PORT);
                    request.AppendLine("MAN: \"ssdp:discover\"");
                    request.AppendLine("MX: 3");
                    request.AppendLine("ST: urn:schemas-upnp-org:device:Printer:1"); // use ssdp:all to get everything
                    request.AppendLine(); // without this extra blank line, query won't run properly
                    var buff = Encoding.UTF8.GetBytes(request.ToString());
                    await stream.WriteAsync(buff.AsBuffer());
                    
                    await Task.Delay(5000);
                    if (!found)
                        break;
                }
            }
        }
