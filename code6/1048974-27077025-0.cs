    int LikeCount(DbLikes likes, int typeId, int type, int likeType)
    {
      return likes.Count(like => 
        like.TypeId == typeId && 
    	like.Type == type && 
    	like.LikeType == likeType);
    }
    
