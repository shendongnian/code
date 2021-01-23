    private void startReceivingTrades()
    {
        NetworkStream serverStream;
            try
            {
                serverStream = clientSocket.GetStream();
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes("SendMeStuff" + System.Environment.NewLine);
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
            catch (Exception ex)
            {
                msg(ex.ToString());
            }
        while (true)
        {
            try
            {
                byte[] inStream = new byte[10025];
                serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                msg("Data from Server : " + returndata);
            }
            catch (Exception ex)
            {
                msg(ex.ToString());
            }
        }
    }
