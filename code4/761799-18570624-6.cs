    // base class that handle receive/sent packets
    class SocketConnection
    {
        // the reason for a Start method is that event can be bound before the Start is executed.
        void Start(Socket socket)
        {
            StartReceive();
        }
        void StartReceive()
        {
            socket.BeginReceive(...);
        }
        void EndReceive()
        {
            socket.EndReceive(...);
            // handle received message.
            // call the ondata event or something
            StartReceive();
        }
    }
    class ClientSocket : SocketConnection
    {
        void Connect()
        {
            Socket socket = new Socket(...);
            socket.Connect(..);
            // start receiving from the client socket.
            base.Start(socket);
        }
    }
    class Server
    {
        List<SocketConnection> _clients;
        void Start()
        {
            // Create server socket + listening etc..
            StartAccept();
        }
        void StartAccept()
        {
            serverSocket.BeginAccept(...);
        }
        void EndAccept()
        {
            Socket serverClientSocket = EndAccept(...);
            // create a base socket handler.....
            SocketConnection clientSocket = new SocketConnection();
       
            _clients.Add(clientSocket);
            // bind the ondata event of the client and pass it to the clientondata event of the server.
            // Start receiving from the socket.
            clientSocket.Start(serverClientSocket);
            // accept new clients.
            StartAccept();
        }
    }
