    public async Task<bool> Authenticate(string clientId, string clientSecret) {
        var response = AsyncRequestAResponse(MakeAuthMessage(clientId, clientSecret));
        return (await response).Type == MessageTypes.AuthenticationResponse
    }
    public Task<bool> AsyncRequestAResponse(??? message) {
        var resultSource = new TaskCompletionSource<Message>();
        _readQueue.Enqueue(resultSource);
        Send(message);
        return resultSource.Task
    }
    private void Listen() {
        ...
        if (_readQueue.Count == 0)
            throw new Exception("Erm, why are they responding before we requested anything?");
        _readQueue.Dequeue().SetResult(msg);
    }
