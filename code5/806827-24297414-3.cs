    public void serverThread()
    {
        UdpClient udpClient = new UdpClient(8080);
        while(true)
        {
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
            string returnData = Encoding.ASCII.GetString(receiveBytes);
            lbConnections.Items.Add(RemoteIpEndPoint.Address.ToString() 
                                    + ":" +  returnData.ToString());
        }
    }
