    // Backing field
    private ICollection<Like> _likesWrapper;
    public ICollection<Like> LikesWrapper { 
    get { 
      // Lazy loading
     if(_likes == null)
     { 
       // Just create a new list or load it from the database.
       _likes = new List<Like>(); 
     }
     return _likes; 
     }
    set { 
     foreach(var val in value)
     {
       //Set the comment and posts
     }
     Likes = value;
    } 
