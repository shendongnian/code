    void Main()
    {
        var s = JsonConvert.SerializeObject(new DocData{id = "hi", Name = "world"}).Dump();
        JsonConvert.DeserializeObject<DocData>(s).Dump();
    }
    public class DocData
    {
        // [JsonProperty("i$d")] // this would work 
        // [JsonProperty("_id")] // as would this
        // [JsonProperty("$name")] // and even this
        [JsonProperty("$id")] // but this fails
        public string id { get; set; }
        public string Name { get; set; }
    }
