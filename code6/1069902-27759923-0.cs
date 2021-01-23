    static class communicator
    {
        // Setting Variables
        static List<UdpClient> UDPreceivers = new List<UdpClient>();
        //static List<TcpListener> TCPreceivers = new List<TcpListener>();
        static IPAddress ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
        static bool listening = false;
        // Listener function
        public static void UDPstartlistening(int port)
        {
            UdpClient UDPreceiver = new UdpClient(port); // udp server
            UDPreceivers.Add(UDPreceiver);
            // Startlistening
            listening = true;
            while (listening)
            {
                try
                {
                    if (UDPreceiver.Available > 0) // Only read if we have some data queued in buffer
                    {
                        //IPEndPoint object will allow us to read datagrams sent from any tracker.
                        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                        // Blocks untill data is received
                        Byte[] receiveBytes = UDPreceiver.Receive(ref RemoteIpEndPoint);
                        string returnData = ByteArrayToString(receiveBytes);
                        // Uses the IPEndPoint object to determine who sent us anything
                        Program.form1.addlog("Received: " + returnData.ToString() + " - from " + RemoteIpEndPoint.Address.ToString() + " on port: " + RemoteIpEndPoint.Port.ToString());
                        // Forward this message to the website
                        Task.Run(() => forwardToWebsite(returnData.ToString(), RemoteIpEndPoint.Address.ToString(), RemoteIpEndPoint.Port, "udp", port));
                    }
                    Thread.Sleep(10);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Source : " + e.Source + "\r\n" + "Message : " + e.Message, "Error");
                }
            }
        }
    }
