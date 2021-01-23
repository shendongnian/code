    using (var client = new HttpClient())
    {
        client.Timeout = TimeSpan.FromSeconds(10);
        var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
    }
