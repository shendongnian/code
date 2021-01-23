    string uri = "your-uri";
    string responseText = await RequestHelper.GetAsync(uri, h =>
    {
        h.Add(HttpRequestHeader.Authorization, "Basic DBHWj7GdKrMEFcUdj7CmR3Hd");
        h.Add(HttpRequestHeader.CacheControl, "no-cache");
    });
    YourDTO yourDtoResponse = JsonConvert.DeserializeObject<YourDTO>(responseText);
