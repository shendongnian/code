    public Task<String> FileToBase64(String filePath)
    {
        using (var client = new WebClient())
        using (var stream = await client.OpenReadTaskAsync(new Uri(filePath)))
        {
            // use stream.ReadAsync
        }
    }
