    public class Product
    {
        [JsonIgnore]
        public int Id { get; set; }          // Should be excluded
        public string Name { get; set; }     // Should be included
        public string Category { get; set; } // Should be included
        [JsonIgnore]
        public int Downloads { get; set; }   // Should be excluded
    }
