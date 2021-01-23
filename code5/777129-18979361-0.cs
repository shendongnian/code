    public async Task<string> UploadImageData(byte[] imageData)
    {
      var clientHandler = new HttpClientHandler();
    
      using (var client = new HttpClient(clientHandler))
      {
        var content = new ByteArrayContent(imageData);
        var response = await client.PostAsync(new Uri("http://example.com/postImage"), content);
        return await response.Content.ReadAsStringAsync();
      }
    }
