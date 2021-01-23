    public void SendChatMessage(string who, string message)
    {
        string name = Context.User.Identity.Name;
        //foreach (var connectionId in _connections.GetConnections(who))
        //{
            //Clients.Client(connectionId).addChatMessage(name + ": " + message);
        //}
        Clients.User(who).addChatMessage(name + ": " + message);
    }
