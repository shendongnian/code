    private void startReceivingTrades()
    {
        NetworkStream serverStream = clientSocket.GetStream();
        byte[] outStream = System.Text.Encoding.ASCII.GetBytes("SendMeStuff" + System.Environment.NewLine);
        serverStream.Write(outStream, 0, outStream.Length);
        serverStream.Flush();
        byte[] inStream = new byte[10025];
        while (true)
        {
            try
            {
                int count = serverStream.Read(inStream, 0, inStream.Length);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream, 0, count);
                msg("Data from Server : " + returndata);
            }
            catch (Exception ex)
            {
                msg(ex.ToString());
            }
        }
    }
