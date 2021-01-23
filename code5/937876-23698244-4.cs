    public Task<BasicAntwort> SendCommand(NetworkClient networkClient, string befehl)
    {
        //Subscribe first to avoid race condition.
        var result = incomingMessages
                            .Where(reply=>reply.Header == befehl)
                            .Timeout(TimeSpan.FromSeconds(2))
                            .Take(1)
                            .ToTask();
        
        //Send command
        networkClient.SendMessage(befehl);
    
        return result;
    }   
