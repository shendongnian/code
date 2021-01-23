    public class UDPServer
    {
        public UDPServer(IEnumerable<int> listenPorts)
        {
            foreach(var port in listenPorts)
            {
                var udpClient = new System.Net.Sockets.UdpClient();
                udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, port));
                udpClient.BeginReceive(Receive, udpClient);
            }
        }
        public void Receive(IAsyncResult ar)
        {
            var udpClient = ar.AsyncState as UdpClient;
            IPEndPoint endPoint = null;
            var data = udpClient.EndReceive(ar, ref endPoint);
            //Do some work and send a response back
            var dataToSend = Encoding.UTF8.GetBytes(String.Concat(Encoding.UTF8.GetString(data).Reverse()));
            udpClient.Client.SendTo(dataToSend, endPoint);
            udpClient.BeginReceive(Receive, udpClient);
        }
    }
