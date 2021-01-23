    public class Request
    {
        public int Id { get; set; }
        public string Message { get; set; }
        [ForeignKey("User")]
        public int ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
    }
