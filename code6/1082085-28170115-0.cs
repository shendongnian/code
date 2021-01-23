    public class Country
    {
        [Key]
        public int Id { get; set; } // or e.g. "string Code" to save e.g. "us"
        public string Name { get; set; }
        public List<ApplicationUsers> Users { get; set; }
    }
