    public async void Main()
    {
       Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
       socket.Connect(new IPEndPoint(new IPAddress(new byte[] { 192, 168, 1, 8 }), 123));
       while (...)
       {
          await SendAsync(socket, new byte[1460], 0, 1460, 0);
       }
       Console.ReadLine();            
    }
