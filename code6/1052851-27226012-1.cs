	public class Comment 
	{
		public string Comment { get; set; }
		public Post Post { get; private set; }
		public VoteType VoteStatus { get; private set; }
		public int Score { get; private set; }
		
		public void UpVote(ICommentService commentService) 
		{
			// for this you'd change your Up/Vote method to return only true/false and not 
			// change the state of your model. On more complex operation, return an CommentResult
			// containing all necessary information to update the comment class
			if(commentService.UpVote(this.Post, this)) 
			{
				// only update the model, if the service operation was successful
				this.Score++;
				this.VoteStatus = VoteType.Up;
			}
		}
	}
