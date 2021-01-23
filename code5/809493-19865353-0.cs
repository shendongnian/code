    public class UserAudit
    {
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("file/folder")]
        public string FileFolder { get; set; }
        [JsonProperty("transaction")]
        public string Transaction { get; set; }
        [JsonProperty("access")]
        public string Access { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
    }
