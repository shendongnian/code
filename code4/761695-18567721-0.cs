    public ClientWrapper(IPAddress serverIP, int port, ErrorMessageHandler method)
    {
        OnErrorRecieved += method;
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(new IPEndPoint(serverIP, port));
        }
        catch (Exception e)
        {
            if (OnErrorRecieved != null)
                OnErrorRecieved(e.Message);
        }
    }
