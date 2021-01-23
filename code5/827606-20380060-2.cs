    class FTServerCode
        {
            IPEndPoint ipEnd;
            Socket sock;
            public FTServerCode()
            {
               ipEnd = new IPEndPoint(IPAddress.Any, 5656);
               sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
               sock.Bind(ipEnd);
            }
            public static string receivedPath;
            public static string curMsg = "Stopped";
            public  void StartServer()
            {
                try
                {
                    curMsg = "Starting...";
                    sock.Listen(100);
    
                    curMsg = "Running and waiting to receive file.";
                    Socket clientSock = sock.Accept();
    
                    byte[] clientData = new byte[1024];
                    StringBuilder sb= new StringBuilder();
                    int receivedBytesLen = 0;
                    while((receivedBytesLen =clientSock.Receive(clientData))>0)
                    {
                    curMsg = "Receiving data..."; 
                    sb.Append(Encoding.ASCII.GetString(clientdata, 0, receivedBytesLen));
                    }
                    //use sb to write into file
                    
                    curMsg = "Saving file...";
    
                    bWrite.Close();
                    clientSock.Close();
                    curMsg = "Reeived & Saved file; Server Stopped.";
                }
                catch (Exception ex)
                {
                    curMsg = "File Receving error.";
                }
            }
        }
