    internal class ResponseRecord
    {
        public string RowIndex { get; set; }
        [JsonProperty(PropertyName = "NameValue"), JsonConverter(typeof(JsonNameValueListToDictionaryConverter))]
        public Dictionary<string, string> Values { get; set; }
    }
