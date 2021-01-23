    protected void Page_Load(object sender, EventArgs e)
    {
        _client = new SwepubSearchServiceClient();
        RegisterAsyncTask(new PageAsyncTask(PageLoadAsync));
    }
    private async Task PageLoadAsync()
    {
        var results = await GetSearchItemsAsync();
        ...
    }
