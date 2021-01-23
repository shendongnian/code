    var obj = JsonConvert.DeserializeObject<List<MyCustomType>>(json);
---
    public class MyCustomType
    {
        public int Id { get; set; }
        [JsonConverter(typeof(MyCustomConverter))]
        public Dictionary<string, string> Data { get; set; }
    }
