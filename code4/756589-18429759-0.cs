    public class Book
    {
        [Key]
        public int Id { get; set; }
        public virtual BookUser User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
    }
