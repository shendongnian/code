    public class Post
    {
        [Key]
        public int PostId { get; set; }
    
        [Required]
        public string PostText { get; set; }
        public byte[] ImagePost { get; set; }
        public byte[] FilePost { get; set; }
        public string TextPost { get; set; }
        [Required]
        public string UserId { get; set; }
    }
