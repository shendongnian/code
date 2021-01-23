    void Main()
    {
        string json = @"{""object"":""payments"",""entry"":[{""id"":""546787862118679"",""time"":1417135022,""changed_fields"":[""actions""]}]}";
        
        Root root = JsonConvert.DeserializeObject<Root>(json);
        
        Entry entry = root.Entry.FirstOrDefault();
    }
    public class Entry
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("time")]
        public int Time { get; set; }
        [JsonProperty("changed_fields")]
        public string[] ChangedFields { get; set; }
    }
    public class Root
    {
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("entry")]
        public Entry[] Entry { get; set; }
    }
