    public static async Task DownloadToStreamAsync(string uri, HttpContent data, Stream target, CancellationToken token)
    {
        using (var client = new HttpClient())
        using (var response = await client.PostAsync(uri, data, token))
        using (var stream = await response.Content.ReadAsStreamAsync())
        {
            await stream.CopyToAsync(target, 4096, token);
        }
    }
