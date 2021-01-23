    public void Send(string message)
    {
       Clients.Caller.broadcastMessage(message); // calling user will be broadcasted the message only.
       // OR use below one.
       Clients.Client(Context.ConnectionId).broadcastMessage(message); // Context.ConnectionId -- contains connectionid for calling user.
    }
