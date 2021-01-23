    public string Get()
    {
        byte[] content = GetContent();
        var data = JsonConvert.SerializeObject(content);
        return data;
    }
