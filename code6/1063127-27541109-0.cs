    static void CONNECTudp()
    {
        Console.WriteLine("Host:");
        IPAddress ipAddress = Dns.Resolve(Console.ReadLine()).AddressList[0];
        Console.WriteLine("Port:");
        int Port = int.Parse(Console.ReadLine());
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, Port);
        // Bind port immediately
        UdpClient udp = new UdpClient(0);
        // Pass UdpClient instance to the thread
        Thread UDPthread = new Thread(() => CONNECTudpthread(udp));
        UDPthread.Start();
        do
        {
            Byte[] sendBytes = Encoding.ASCII.GetBytes(Console.ReadLine());
            udp.Send(sendBytes, sendBytes.Length, ipEndPoint);
        } while (true);
    }
    static void CONNECTudpthread(UdpClient udp)
    {
        do
        {
            try
            {
                // Though it's a "ref", the "remoteEP" argument is really just
                // for returning the address of the sender.
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udp.Receive(ref ipEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                Console.WriteLine(returnData);
            }
            catch (Exception)
            {
            }
        } while (true);
    }
