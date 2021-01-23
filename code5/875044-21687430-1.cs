    public ActionResult Post(PostModel post)
    {
        #if !DEBUG
        if(!HttpContext.User.Identity.IsAuthenticated)
        {
            return new HttpUnauthorizedResult();
        }
        #endif
        User user = GetLoggedInUser(); //Returns null because the user
                                       //is not authenticated
        Post createdPost = new Post
        {
           Title = post.Title,
           Content = post.Content,
           //Uh oh, the user is not logged in. This post will not have an author!
           Author = user,
           PostDate = DateTime.Now
        };
        DbContext.Posts.Add(createdPost);
        DbContext.SaveChanges();
        return View();
    }
