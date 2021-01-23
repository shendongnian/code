    public class Foo
    {
        [JsonIgnore]
        public int ParentId { get; set; }
        
        [NotMapped]
        public int FooParent { get; set; }
    }
