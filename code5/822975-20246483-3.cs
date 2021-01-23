    protected async void Page_Load(object sender, EventArgs e)
    {
        _client = new SwepubSearchServiceClient();
        var results = await GetSearchItemsAsync();
        ...
    }
