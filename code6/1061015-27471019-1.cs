    public class MenuJson
    {
        [JsonProperty("id")]
        public string id { get; set; }
    
        [JsonProperty("children")]
        public List<MenuJson> children { get; set; }
    }
    var list = JsonConvert.DeserializeObject<List<MenuJson>>(json);
