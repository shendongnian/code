    public class MenuJson
    {
        [JsonProperty("id")]
        public string id { get; set; }
    
        [JsonProperty("children")]
        public List<MenuJson> children { get; set; }
    }
    var object = JsonConvert.DeserializeObject<MenuJson>(json);
