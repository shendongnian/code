    var post = (
      from c in Db.Comments
      where c.Type == postType
      group c by c.TypeId into com
      join p in Db.Posts on com.Key equals p.Pid
      where p.Pid == postId
      select new
      {
        Post = p,
        Comments = com.Select(c => new
    	  {
    	    Comment = c,
    		like = LikeCount(Db.Likes, c.CommentId, commentType, likeType),
    		dislike = LikeCount(Db.Likes, c.CommentId, commentType, dislikeType)
    	  }),
        Likes = LikeCount(Db.Likes, p.Pid, postType, likeType),
        Dislikes = LikeCount(Db.Likes, p.Pid, postType, dislikeType),
      }).FirstOrDefault();
