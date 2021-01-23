    private List<Socket> _clients = new List<Socket>();
    public static void AcceptCallback(IAsyncResult ar) {
        // Signal the main thread to continue.
        allDone.Set();
        // Get the socket that handles the client request.
        Socket listener = (Socket) ar.AsyncState;
        Socket handler = listener.EndAccept(ar);
        // Create the state object.
        StateObject state = new StateObject();
        state.workSocket = handler;
        handler.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,
            new AsyncCallback(ReadCallback), state);
        _clients.Add(handler); // Maintain connected clients
    }
    public void BroadcastMessage(string message)
    {
        // Send the message to all clients
        var bytes = Encoding.ASCII.GetBytes(message);
        foreach(var c in _clients)
        {
            c.BeginSend(bytes, 0, bytes.Length, SocketFlags.Broadcast, OnMessageBroadcast, c);
        }
    }
    private void OnMessageBroadcast(IAsyncResult res)
    {
        Socket client = (Socket)res.AsyncState;
        client.EndSend(res);
    }
