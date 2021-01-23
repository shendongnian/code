    public async Task Test()
    {
        using (var client = new HttpClient())
        {
            var uri = new Uri("http://www.google.com");
            string html = await client.GetStringAsync(uri);
    
            var webPage = ParseHtml(html, uri);
        }
    }
