    public class CommentModel
    {
        public CommentModel()
        {
            this.Replies = new List<ReplyModel>();
        }
        public int Id { get; set; }
     //   [Required(ErrorMessage="Don't miss to put your name.")]
        public string name { get; set; }
      //  [Required(ErrorMessage = "Don't leave your comments empty.")]
        public string comment { get; set;}
        public List<ReplyModel> Replies { get; set; }
    }
    public class CreateViewModel
    {
        public CreateViewModel()
        {
            this.Comments = new List<CommentModel>();
        }
        public CommentModel CreateComment { get; set; } // this line is optional
        public ReplyModel CreateReply { get; set; }
        public List<CommentModel> Comments { get; set; }
        public ReplyModel Reply { get; set; }
    }
