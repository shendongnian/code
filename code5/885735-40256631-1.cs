    class Program
    {
        static readonly List<string> addressList = new List<string>();
        static readonly IPAddress multicastAddress = IPAddress.Parse("239.255.255.250");
        const int multicastPort = 3702;
        const int unicastPort = 0;
        static void Main(string[] args)
        {
            DeepDiscovery();
            Console.ReadKey();
        }
        public static void DeepDiscovery()
        {
            string probeMessageTemplate = @"<s:Envelope xmlns:s=""http://www.w3.org/2003/05/soap-envelope"" xmlns:a=""http://schemas.xmlsoap.org/ws/2004/08/addressing""><s:Header><a:Action s:mustUnderstand=""1"">http://schemas.xmlsoap.org/ws/2005/04/discovery/Probe</a:Action><a:MessageID>urn:uuid:{messageId}</a:MessageID><a:ReplyTo><a:Address>http://schemas.xmlsoap.org/ws/2004/08/addressing/role/anonymous</a:Address></a:ReplyTo><a:To s:mustUnderstand=""1"">urn:schemas-xmlsoap-org:ws:2005:04:discovery</a:To></s:Header><s:Body><Probe xmlns=""http://schemas.xmlsoap.org/ws/2005/04/discovery""><d:Types xmlns:d=""http://schemas.xmlsoap.org/ws/2005/04/discovery"" xmlns:dp0=""http://www.onvif.org/ver10/device/wsdl"">dp0:Device</d:Types></Probe></s:Body></s:Envelope>";
            foreach (IPAddress localIp in
                Dns.GetHostAddresses(Dns.GetHostName()).Where(i => i.AddressFamily == AddressFamily.InterNetwork))
            {
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.Bind(new IPEndPoint(localIp, unicastPort));
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(multicastAddress, localIp));
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 255);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                socket.MulticastLoopback = true;
                var thread = new Thread(() => GetSocketResponse(socket));
                var probeMessage = probeMessageTemplate.Replace("{messageId}", Guid.NewGuid().ToString());
                var message = Encoding.UTF8.GetBytes(probeMessage);
                socket.SendTo(message, 0, message.Length, SocketFlags.None, new IPEndPoint(multicastAddress, multicastPort));
                thread.Start();
            }
        }
        
        public static void GetSocketResponse(Socket socket)
        {
            try
            {
                while (true)
                {
                    var response = new byte[3000];
                    EndPoint ep = socket.LocalEndPoint;
                    socket.ReceiveFrom(response, ref ep);
                    var str = Encoding.UTF8.GetString(response);
                    var matches = Regex.Matches(str, @"http://\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b/onvif/device_service");
                    foreach (var match in matches)
                    {
                        var value = match.ToString();
                        if (!addressList.Contains(value))
                        {
                            Console.WriteLine(value);
                            addressList.Add(value);
                        }
                    }
                    //...
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //...
            }
        }
    }
