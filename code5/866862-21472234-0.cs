    public class PostCreator 
    {
        public PostCreator()
        {
            CreatedId = null;
        }
    
        public void CreatePost(database::Post newPost)
        {
            if (CreatedPostId != null)
                throw new InvalidOperationException("Post Already Created!");
    
            using(var db = new database::MainModelContainer())
            {
                db.Posts.Add(newPost);
                db.SaveChanges();
                CreatedPostId = newPost.Id;
            }
        }
    
        public int? CreatedPostId { get; private set; }
    }
