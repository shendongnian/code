     public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string commentText { get; set; }
        public int productID { get; set; }
        [ForeignKey("productID")]
        public virtual Product Product { get; set; }
    }
