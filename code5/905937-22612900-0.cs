    internal class GetTokenRootInfo
    {
        [JsonProperty("totals")]
        public static Totals totals { get; set; }
        [JsonProperty("IDCode")]
        public static string IDCode { get; set; }
        [JsonProperty("Key")]
        public static string Key { get; set; }
    }
