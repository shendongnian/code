        byte[] ba = Encoding.UTF8.GetBytes(message);
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        s.Connect(IPAddress.Loopback, port);
        total = s.Send(ba, SocketFlags.None);
        total = s.Receive(ba, 0, ba.Length, SocketFlags.None);
        if (total > 0)
        {
            Output(Encoding.UTF8.GetString(ba, 0, total));
        }
