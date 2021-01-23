    void AcceptConn(IAsyncResult ia)
    {
        Socket client;
        try
        {
            Socket oldserver = (Socket) ia.AsyncState;
            client = oldserver.EndAccept(ia);
    
            StateObject state = new StateObject();
            state.workSocket = client;
            client.ReceiveTimeout = 1000;
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveData), state);
            server.BeginAccept(new AsyncCallback(AcceptConn), server);
        }
        catch (Exception ex) 
        {
            AppendIncomingData(txtError, "AcceptConn Exception : " + ex.Message);
        }
    }
