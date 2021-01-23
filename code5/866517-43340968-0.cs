    bool CheckOpenVPNudp(string ip, int port)
            {
                IPEndPoint RemoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                byte[] data = { 56, 1, 0, 0, 0, 0, 0, 0, 0 }; //OpenVPN client welcome datagram
                server.SendTo(data, data.Length, SocketFlags.None, RemoteEndPoint);
                server.ReceiveTimeout = 15000; //15 seconds timeout
                EndPoint Remote = (EndPoint)(RemoteEndPoint);
                try
                {
                    byte[] answer = new byte[1024];
                    int recv = server.ReceiveFrom(answer, ref Remote);
                    Console.WriteLine("Message received from {0}:", Remote.ToString());
                    Console.WriteLine(System.Text.Encoding.ASCII.GetString(answer, 0, recv));
                    return true;
    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
    
            }
