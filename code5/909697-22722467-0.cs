    [JsonObject(MemberSerialization.OptIn)]
    class Document
    {
        [JsonProperty("title", Required = Required.Always, Order = 1)]
        public string Title { get; set; }
        [JsonProperty("date", Order = 3)]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Date { get; set; }
        [JsonProperty(Order = 2)]
        public TypeIdentifier DocTypeIdentifier { get; set; }
        public string OtherStuff { get; set; }
    }
