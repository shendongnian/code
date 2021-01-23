    public class MyClass
    {
        [JsonConverter(typeof(MyDictionaryConverter<int>))]
        public Dictionary<string, int> MyDict { get; set; }
    }
