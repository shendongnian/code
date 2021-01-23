    private static TResponse GetResponseValue<TResponse>(WebRequest webRequest)
    {
        using (var webResponse = webRequest.GetResponse())
        using (var responseStream = webResponse.GetResponseStream())
        using (var streamReader = new StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var jsonSerializer = new JsonSerializer();
            return jsonSerializer.Deserialize<TResponse>(jsonTextReader);
        }
    }
