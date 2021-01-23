    private readonly Queue<ResponseMessageType> _responseQueue = new Queue<ResponseMessageType>();
    public async Task<bool> Authenticate(string clientId, string clientSecret) {
        var response = AsyncRequestAResponse(MakeAuthMessage(clientId, clientSecret));
        return (await response).Type == MessageTypes.AuthenticationResponse
    }
    public Task<bool> AsyncRequestAResponse(RequestMessageType request) {
        var responseSource = new TaskCompletionSource<ResponseMessageType>();
        _responseQueue.Enqueue(responseSource);
        Send(request);
        return responseSource.Task
    }
    private void Listen() {
        ...
        if (_responseQueue.Count == 0)
            throw new Exception("Erm, why are they responding before we requested anything?");
        _responseQueue.Dequeue().SetResult(msg);
    }
