    class Post{
       public virtual ICollection<Like> Likes {set;get;}
      
    }
    
    class Comment{
       public virtual ICollection<Like> Likes {set;get;}
      
    }
    
    Then:
    
    class Like{
      //....
    }
