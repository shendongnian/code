    public class CreateViewModel
    {
        public CreateViewModel()
        {
            this.Comments = new List<CommentModel>();
            this.Replies = new List<ReplyModel>();
        }
        public CommentModel CreateComment { get; set; } // this line is optional
        public ReplyModel CreateReply { get; set; }
        public List<CommentModel> Comments { get; set; }
        public List<ReplyModel> Replies { get; set; }
        public ReplyModel Reply { get; set; }
    }
