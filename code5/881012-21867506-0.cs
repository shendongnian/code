    public async Task<HttpResponseMessage> Post(string id, string fileName)
    {
        string url = string.Format("http://api.sonicapi.com/file/upload?access_id={0}", id);
        var stream = new FileStream(fileName, FileMode.Open);
        string name = Path.GetFileName(fileName);
        var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };
        var streamContent = new StreamContent(stream);
        streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
        streamContent.Headers.ContentDisposition.Name = "\"file\"";
        streamContent.Headers.ContentDisposition.FileName = "\"" + name + "\"";
        streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        var content = new MultipartFormDataContent { streamContent };
        HttpResponseMessage message = await client.PostAsync(url, content);
        string s = await message.Content.ReadAsStringAsync();
        return message;
    }
