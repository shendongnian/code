    private async Task<T> LoadJSONToObject<T>(string url, string rootProperty)
    {
        //get data
        var json = await GetResultStringAsync(url);
        if (string.IsNullOrWhiteSpace(rootProperty))
            return JsonConvert.DeserializeObject<T>(json);
        var jObject = JObject.Parse(json);
        var parsedJson = jObject[rootProperty].ToString();
        //deserialize it
        return JsonConvert.DeserializeObject<T>(parsedJson);
    }
