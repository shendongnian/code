    public class Video {
    // Id etc.
    public virtual IList<Comment> Comments {get; set;}
    }
    
    public class Youtube : Video{
    // Id etc.
    }
    
    public class Vimeo : Video{
    // Id etc.
    }
    
    public class Comment {
    // comment props
     public virtual IList<Video> Videos {get; set;}
    }
