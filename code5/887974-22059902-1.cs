    private readonly IClient client;
    private readonly ISerializer serializer;
    public YourService(IClient client, ISerializer serializer)
    {
        _client = client;
        _serializer = serializer;
    }
    public async Task<List<Song>> FetchSongsAsync(String query)
    {
        try
        {
            var result = await client.GetStringAsync(new Uri("http://example.com"));
            return _serializer.DeserializeObject<RootObject>(result);
        }
        catch (Exception)
        {
            return null;
        }
    }
