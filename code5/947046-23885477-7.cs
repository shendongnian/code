    // launch this in a background thread
    private static void UDPListen()
    {
        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
        var udpClient = new UdpClient(10000);
        while (true)
        {
            var buffer = udpClient.Receive(ref remoteEndPoint);
            var loggingEvent = System.Text.Encoding.Unicode.GetString(buffer);
            // write the log to your pane
        }
    }
