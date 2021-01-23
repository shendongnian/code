    public async Task<string> LoginRequest(string token)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        var result = serializer.Serialize(token);
        WebClient client = new WebClient();
        client.Headers["ContentType"] = "application/json";
        var response = await client.UploadStringTaskAsync(URI, HTTP_POST, result);
        // do something with the response here, eg. JsonConvert.DeserializeObject();
        
        return "true";
    }
