    public ActionResult AddComment(int blogPostId)
    {
      return View(new Comment { BlogPostId = blogPostId} ); // maybe some validating on the blogPostId
    }
    
    [HttpPost]
    public ACtionResult AddComment(Comment model)
    {
      // do some manual validating yourself first, e.g. check if the model.BlogPostId still exists. One could have changed this to test your security...
       
      if (ModelState.IsValid)
      {
        // save the new comment here, for examle:
        var commentRepo = new CommentRepository();
        commentRepo.Insert(model);
        commentRepo.Save();
    
        return Redirect.... // redirect to for example the post page
      }
      return View(model);
    }
