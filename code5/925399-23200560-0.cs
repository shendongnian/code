    public class Product
    {
        [Exclude]
        public int Id { get; set; }          // Should be excluded
        public string Name { get; set; }     // Should be included
        public string Category { get; set; } // Should be included
        [Exclude]
        public int Downloads { get; set; }   // Should be excluded
    }
