    [JsonConverter(typeof(StringEnumConverter))]
    public enum ResposeStatus
    {
        [EnumMember(Value = "success value")]
        Success,
        [EnumMember(Value = "fail value")]
        Fail,
        [EnumMember(Value = "error value")]
        Error
    };
