    public class Post
    {
         public Image Photo { get; private set; }
         public string Text { get; private set; }
         public Post(Image originalPost)
         {
             Photo = originalPost;
         }
         public Post(string originalPost)
         {
             Photo = originalPost.Photo;
         }
    }
