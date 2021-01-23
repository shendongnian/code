    public static bool PingHost(string _HostURI, int _PortNumber)
    {
        try
        {
            TcpClient client = new TcpClient(_HostURI, _PortNumber);
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error pinging host:'" + _HostURI + ":" + _PortNumber.ToString() + "'");
            return false;
        }
    }
