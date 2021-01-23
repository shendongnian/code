    var obj = JsonConvert.DeserializeObject<MyCustomType>(json);
---
    public class MyCustomType
    {
        public int Id { get; set; }
        public List<string> Data { get; set; }
    }
