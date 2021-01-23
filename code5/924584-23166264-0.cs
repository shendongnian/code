    class Program
    {
        static void Main(string[] args)
        {
            var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8500);
            NetUDP udp = new NetUDP(serverEndPoint);
            UdpClient localClient = new UdpClient();
            Task.Delay(20000);
            var dgram = Encoding.ASCII.GetBytes("Hello Server");
            localClient.Send(dgram, dgram.Length, serverEndPoint);  // Send "Hello Server" to Server
            Console.Read();
        }
    }
    class NetUDP
    {
        private UdpClient udp;
        private IPEndPoint endPont;
        public NetUDP() { }
        public NetUDP(IPEndPoint serverEndPoint)
        {
            udp = new UdpClient(serverEndPoint);  // Bind the EndPoint
            // Receive any IPAddress send to the 8555 port
            IPEndPoint receiveEndPoint = new IPEndPoint(IPAddress.Any, 8555);
            Task.Run(() =>
                {
                    try
                    {
                        while (true)
                        {
                            // This Receive will block until receive an UdpClient
                            // So, run in another thread in thread pool
                            var bytes = udp.Receive(ref receiveEndPoint);
                            Console.WriteLine(Encoding.ASCII.GetString(bytes));
                        }
                    }
                    catch (Exception ex)
                    {
                        // TODO
                    }
                    finally
                    {
                        udp.Close();
                    }
                });
        }
    }
