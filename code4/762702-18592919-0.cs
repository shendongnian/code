    string json = @"{""Service Provider"":""Test""}";
    var obj = JsonConvert.DeserializeObject<TempObject>(json);
    public class TempObject
    {
        [JsonProperty("Service Provider")]
        public string ServiceProvider;
    }
