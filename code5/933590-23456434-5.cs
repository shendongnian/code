    static BlockingCollection<byte[]> buffer = new BlockingCollection<byte[]>();
    public async void Main()
    {
       Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
       socket.Connect(new IPEndPoint(new IPAddress(new byte[] { 192, 168, 1, 8 }), 123));
       while (!buffer.IsCompleted)
       {
          var data = buffer.Take();
          await SendAsync(socket, data, 0, data.Length, 0);
       }
       Console.ReadLine();            
    }
