    private void DoWork()
        {
            try
            {
                client = new TcpClient();
                client.Connect(new IPEndPoint(IPAddress.Parse(ip), intport));
                //Say thread to sleep for 1 secs.
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                // Log the error here.
                client.Close();
                return;
            }
            try
            {
                using (stream = client.GetStream())
                {
                    byte[] notify = Encoding.ASCII.GetBytes("Hello");
                    stream.Write(notify, 0, notify.Length);
                    byte[] data = new byte[1024];
                    while (!_shutdownEvent.WaitOne(0))
                    {
                        int numBytesRead = stream.Read(data, 0, data.Length);
                        if (numBytesRead > 0)
                        {
                            line = Encoding.ASCII.GetString(data, 0, numBytesRead);
                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }        
        }
