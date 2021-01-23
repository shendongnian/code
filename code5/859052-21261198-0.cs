    using (var fileIO = File.OpenRead(@"C:\temp\fake.bin"))
    using(var clientSocket = new System.Net.Sockets.TcpClient(ip, port).GetStream())
    {
      // Send Length (Int64)
      clientSocket.Write(BitConverter.GetBytes(clientSocket.Length, 0, 8));
      var buffer = new byte[1024 * 8];
      int count;
      while ((count = fileIO.Read(buffer, 0, buffer.Length)) > 0)
        clientSocket.Write(buffer, 0, count);
    }
