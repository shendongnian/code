    List<TcpClient> connectedClients = new List<TcpClient>();
    
    private void ListenForClients()
        {
            this.tcpListener.Start();
    
            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();
                connectedClients.Add(client);
    
                //create a thread to handle communication 
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }
