    public ActionResult ReadPost(int id)
    {
      Post post = db.Posts.Find(id);
      PostVM model = new PostVM()
      {
        PostTitle = post.PostTitle,
        PostContent = post.PostContent,
        PostAuthor = post.UserProfile.UserName,
        PostDate = post.DateCreated,
        Comments = post.Replies.Select(r => new CommentVM()
        {
          Comment = r.Reply1,
          CommentAuthor = r.UserProfile.UserName,
          CommentDate = r.ReplyDate
        })
      };
      return View(model);
    }
