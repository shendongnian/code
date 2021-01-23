    private await Task<System.IO.Stream> Upload(string url, string param1, Stream fileStream, byte[] fileBytes)
    {
        HttpContent stringContent = new StringContent(param1);
        HttpContent fileStreamContent = new StreamContent(fileStream);
        HttpContent bytesContent = new ByteArrayContent(fileBytes);
    
        var handler = new HttpClientHandler();
        var md5Handler = new RequestContentMd5Handler();
        md5Handler.InnerHandler = handler;
    
        using (HttpClient client = new HttpClient(md5Handler))
        {
            using (MultipartFormDataContent formData = new MultipartFormDataContent())
            {
                formData.Add(stringContent, "param1", "param1");
                formData.Add(fileStreamContent, "file1", "file1");
                formData.Add(bytesContent, "file2", "file2");
    
                using (var response = await client.PostAsync(url, formData))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        return null;
                    }
    
                    return await response.Content.ReadAsStreamAsync();
                }
            }
        }
    }
