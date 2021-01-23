    public class Foo
    {
        [JsonIgnore]
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class Bar : Foo 
    { }
