    public static class NetworkHelper
        {
            public static bool CheckIPAddressAndPortNumber(IPAddress ipAddress, int portNumber)
            {
                return PingIPAddress(ipAddress) && CheckPortNumber(ipAddress, portNumber);
            }
            public static bool PingIPAddress(IPAddress iPAddress)
            {
                var ping = new Ping();
                PingReply pingReply = ping.Send(iPAddress);
    
                if (pingReply.Status == IPStatus.Success)
                {
                    //Server is alive
                    return true;
                }
                else
                    return false;
            }
            public static bool CheckPortNumber(IPAddress iPAddress, int portNumber)
            {
                var retVal = false;
                try
                {
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        tcpClient.Connect(iPAddress, portNumber);
                        retVal = tcpClient.Connected;
                        tcpClient.Close();
                    }
                    return retVal;
                }
                catch (Exception)
                {
                    return retVal;
                }
    
            }
        }
