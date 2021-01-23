    [JsonConverter(typeof(DefaultUnknownEnumConverter))]
    public enum Colors
    {
        Unknown,
        Red,
        Blue,
        Green,
    }
    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int) NotFound)]
    public enum Colors
    {        
        Red = 0,
        Blue,
        Green,
        NotFound
    }
