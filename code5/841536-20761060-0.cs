    public class BlogPost
    {
      // properties such as id, title, body, etc. Don't forget to add validation attributes.
    
      public virtual IList<Comment> Comments {get;set;}
    }
    
    public class Comment
    {
      // again properties such as id, author, e-mail, etc. and validation
    
      // the FK to BlogPost
      public int BlogPostId {get;set;}
      public virtual BlogPost BlogPost {get;set;}
    }
