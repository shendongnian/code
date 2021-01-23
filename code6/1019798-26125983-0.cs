    using (HttpClient client = new HttpClient())
    {
        var content = new StringContent(data, Encoding.UTF8, "application/xml");
        var response = await client.PostAsync(uri, content);
        var respString = await response.Content.ReadAsStringAsync();
    }
