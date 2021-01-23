    public class Product
    {
        [JsonProperty("code")]
        public long Code {get;set;}
        [JsonProperty("name")]
        public string Name {get;set;}
        [JsonProperty("packs")]
        public Pack[] Packs {get;set;}
    }
