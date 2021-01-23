    Connection.Broadcast(chatData); // this will broadcast data to all connected clients.
    protected override Task OnConnectedAsync(IRequest request, string connectionId)
    {
        _clients.Add(connectionId, string.Empty);
        ChatData chatData = new ChatData("Server", "A new user has joined the room.");
        return Connection.Broadcast(chatData);
    }
