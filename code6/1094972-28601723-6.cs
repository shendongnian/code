    public static async Task<List<T>> GetResponseAsync<T>(string url)
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        var response = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);
        Stream stream = response.GetResponseStream();
        StreamReader strReader = new StreamReader(stream);
        string text = await strReader.ReadToEndAsync();
        return JsonConvert.DeserializeObject<List<T>>(text);
    }
