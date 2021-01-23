    // Process the client connection.       
    public static void DoAcceptTcpClientCallback(IAsyncResult ar) 
    {
        TcpListener listener = (TcpListener) ar.AsyncState;
            
        TcpClient client = listener.EndAcceptTcpClient(ar);
                
        //add to your client list
        clients.Add(client);
      }
