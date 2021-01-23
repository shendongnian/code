    public class CommentHub:Hub
    {
        public void AddComment(string Comment)
        {
            var Context = new SignalREntities();
            Comment com = new Comment();
            com.Comment1 = Comment;
            Context.Comments.Add(com);
            Context.SaveChanges();
           
            Clients.All.AddNewComment(Comment);
          
        }
      
    }
