    public async void LoadPicture(string url)
    {
        bool worker = await GetURLContentsAsync(url);
    }
    private async Task<bool> GetURLContentsAsync(string url)
    {
        var webReq = (HttpWebRequest)WebRequest.Create(url);             
        using (WebResponse response = await webReq.GetResponseAsync())
        {
            .
            .
            .
