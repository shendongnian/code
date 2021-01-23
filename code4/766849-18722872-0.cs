    Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    clientSocket.NoDelay = true;
                
    IPAddress ip = IPAddress.Parse("192.168.192.6");
    IPEndPoint ipep = new IPEndPoint(ip, 9100);
    clientSocket.Connect(ipep);
    
    byte[] fileBytes = File.ReadAllBytes("test.txt");
    
    clientSocket.Send(fileBytes);
    clientSocket.Close();
