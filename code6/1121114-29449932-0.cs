    // I chose MemberSerialization.OptIn so that all members need to be
    // included explicitly, rather than implicitly (which is the default)
    [JsonObject(MemberSerialization.OptIn)]
    public class ServerInfo
    {
        [JsonProperty]
        public string message { get; set; }
        [JsonProperty]
        public string message_timestamp { get; set; }
    }
