    public void ProcessMessage(object client)
    {
        if (client != null)
        {
            tcpClient = client as TcpClient;
        }
        this.messageReceived = false;
        NetworkStream clientReadStream = tcpClient.GetStream();
        byte[] message = new byte[tcpClient.ReceiveBufferSize];
        int byteRead = 0;
        while (true)
        {
            byteRead = 0;
            if (tcpClient.Connected)
            {
                try
                {
                    byteRead = clientReadStream.Read(message, 0, tcpClient.ReceiveBufferSize);
                }
                catch (Exception)
                {
                    throw;
                }
                if (byteRead == 0)
                {
                    break;
                }
                else
                {
                    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                    this.request = encoder.GetString(message, 0, byteRead);
                    if (!string.IsNullOrEmpty(this.request))
                    {
                        this.messageReceived = true;
                    }
                }
            }
        }
    }
