    if (!Dict.connectedClients.Any((a) => a.Value.Socket == socket))
    {
        acceptedClient.Socket = socket;
        Dict.connectedClients.TryAdd(getFirstKey(), acceptedClient);
    }
    
    acceptedClient = Dict.connectedClients.Single((a) => a.Value.Socket == socket).Value;
