    using System.Net.Sockets;
    
    private void DoWork()
    {
        while (!_shutdownEvent.Wait(0))
        {
            TcpClient client = new TcpClient();
    
            try
            {
                // This is a blocking call.  You might want to consider one of the
                // asynchronous methods...
                client.Connect(new IPEndPoint(IPAddress.Parse("192.168.1.100"), 8181));
            }
            catch (Exception ex)
            {
                // Log the error here.
                client.Close();
                continue;
            }
    
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] notify = Encoding.ASCII.GetBytes("Client here");
                    stream.Write(notify, 0, notify.Length);
    
                    byte[] data = new byte[1024];
                    while (!_shutdownEvent.WaitOne(0))
                    {
                        int numBytesRead = client.Read(data, 0, data.Length);
                        if (numBytesRead > 0)
                        {
                            string msg = Encoding.ASCII.GetString(data, 0, numBytesRead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error here.
                client.Close();
            }
        }
    }
