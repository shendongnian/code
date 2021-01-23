    bool isConnected = true;
    try
    {
      Socket s = new Socket(AddressFamily.InterNetwork,
        SocketType.Stream,
        ProtocolType.Tcp);
     
      s.Connect(yourIpAddress, yourPort);
      byte[] msg = Encoding.UTF8.GetBytes("testing");
      s.Send(msg);
    }
    catch(Exception e)
    {
      isConnected = false;
    }
