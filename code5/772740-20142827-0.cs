    public async Task<ObservableCollection<News>> GetNews()
    {
        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            var result = await client.GetStringAsync(source);
            var parseResult = XDocument.Parse(result);
            . . .
        }
        catch(Exception ex)
        {
           //throw
        }
    }
