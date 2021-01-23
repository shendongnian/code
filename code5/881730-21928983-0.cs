    try{
    System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
    clientSocket = Connect(IP, Port);
    //Thread.Sleep(400);
    
    NetworkStream networkStream = clientSocket.GetStream();
    Send(networkStream, "My Data To send");
    networkStream.Flush();
    }catch(Exception E)
    {
     //Log
     //Its always best to catch the actual exception than general exception
     //Handle gracefully
    }
