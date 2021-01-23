    class Employer
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("setor")]
        public string Setor { get; set; }
    }
    class Employers : List<Employer>
    {
    }
    
    Employers employers = JObject.Parse(json)["result"]["employers"].ToObject<Employers>();
