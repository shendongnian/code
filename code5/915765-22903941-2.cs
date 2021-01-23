    public static bool PingHost(string hostUri, int portNumber)
    {
        try
        {
            using (var client = new TcpClient(hostUri, portNumber))
                return true;
        }
        catch (SocketException ex)
        {
            MessageBox.Show("Error pinging host:'" + hostUri + ":" + portNumber.ToString() + "'");
            return false;
        }
    }
