    public class Tag
    {
        // you need an ID
        public int Id { get; set; }
        public string Text { get; set; }
        [Required]
        public virtual Post Post { get; set; }
    }
