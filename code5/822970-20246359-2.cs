    protected async void Page_Load(object sender, EventArgs e)
    {
        ...
        var results = await GetAsyncSearchItems(...)
        ... do something with the results
    }
    private static async SearchItem[] GetAsyncSearchItems()
    {
        ... await stuff
        return list;
    }
