    async Task<ReadOnlyCollection<Response>> GetResponsesAsync(IEnumerable<Request> fromRequests)
    {
        return (await Task.WhenAll(fromRequests.Select(GetResponse))).ToList().AsReadOnly();
    }
    async Task<Response> GetResponseAsync(Request fromRequest)
    {
        await Task.Delay(10000); //simulate some long running async op.
        return new Response();
    }
