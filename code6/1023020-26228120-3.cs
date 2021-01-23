    using (var handler = new HttpClientHandler())
    {
        handler.AllowAutoRedirect = false;
        using (var client = new HttpClient(handler))
        {
            var response = await client.GetAsync("shortUrl");
            var longUrl = response.Headers.Location.ToString();
        }
    }
