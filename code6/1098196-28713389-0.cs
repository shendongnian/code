    public void Send(string username, string message)
    {
        context.Clients.Caller.updateMessagesCaller(message);
        context.Clients.User(username).updateMessages(message);
    }
