    // Backing field
    private ICollection<Like> _likes;
    public virtual ICollection<Like> Likes { 
    get { 
     if(_likes == null) // Do something{ } 
     return _likes; 
     }
    set { 
     _likes = value; 
     //Set the comment and posts
     }
    } 
