	public interface ICommentService
	{
		void UpVote(Post post, Comment comment);
		void DownVote(Post post, Comment comment);
	}
	public class CommentRestService 
	{
		IRestClient client;
		public CommentRestService(IRestClient client)
		{
			this.client = client;
		}
		
		public void UpVote(Post post, Comment comment)
		{
			var postId = post.Id;
			var commentId = comment.Id;
			
			var request = ...; // create your request and send it
			
			var response = request.GetResponse();
			
			// successfully submitted
			if(response.Status == 200) 
			{
				comment.VoteStatus = VoteType.Up;
				comment.Score += 1;
			}
		}
		
		public void DownVote(Post post, Comment comment)
		{
			var postId = post.Id;
			var commentId = comment.Id;
			
			var request = ...; // create your request and send it
			
			var response = request.GetResponse();
			
			// successfully submitted
			if(response.Status == 200) 
			{
				comment.VoteStatus = VoteType.Down;
				comment.Score -= 1;
			}
		}
	}
