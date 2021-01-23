        static void Main(string[] args)
        {
            //Configuration
            var interfaceIp = IPAddress.Parse("192.168.9.121");
            var interfaceEndPoint = new IPEndPoint(interfaceIp, 60001);
            var multicastIp = IPAddress.Parse("230.230.230.230");
            var multicastEndPoint = new IPEndPoint(multicastIp, 60001);
            //initialize the socket
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.ExclusiveAddressUse = false;
            socket.MulticastLoopback = false;
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
            MulticastOption option = new MulticastOption(multicastEndPoint.Address, interfaceIp);
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, option);
            //bind on a network interface
            socket.Bind(interfaceEndPoint);
            //initialize args for sending packet on the multicast channel
            var sockArgs = new SocketAsyncEventArgs();
            sockArgs.RemoteEndPoint = multicastEndPoint;
            sockArgs.SetBuffer(new byte[1234], 0, 1234);
            //send an empty packet of size 1234 every 3 seconds
            while (true)
            {
                socket.SendToAsync(sockArgs);
                Thread.Sleep(3000);
            }
        }
