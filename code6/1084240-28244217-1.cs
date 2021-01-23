    public static async Task<ReadOnlyCollection<Response>> GetResponse(IEnumerable<Request> fromRequests)
    {
        return (await Task.WhenAll(fromRequests.Select(GetResponse))).ToList().AsReadOnly();
    }
    //convenience method
    public static Task<Response> GetResponse(Request fromRequest)
    {
        return Task.Run(async () =>
        {
            await Task.Delay(10000); //simulate some long running async op.
            return new Response();
        });
    }
