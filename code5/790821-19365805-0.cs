    public async Task DownloadAndStoreAsync()
    {
        //service passed in through ctor
        var urls = _getContentUrls.GetAll();
        var content = await DownloadAllAsync(urls);
        //do stuff with content here
    }
