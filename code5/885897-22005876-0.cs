    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int RefCount { get; set; }
        public virtual List<BlogEntry> BlogEntries { get; set; } // MODIFICATION
    }
