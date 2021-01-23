    public void WriteJson(string json)
    {
        var jsonBytes = Encoding.UTF8.GetBytes(json);
        responseStream.Write(jsonBytes, 0, jsonBytes.Length);
        responseStream.Seek(0, SeekOrigin.Begin);
    }
