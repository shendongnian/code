    public ActionResult Create(int threadId, CreatePostInputModel input)
    {
       if (ModelState.IsValid)
       {
          var content = sanitizer.Sanitize(input.Content);
    
          var post = new Post
          {
                     ThreadId = threadId,
                     AuthorId = this.User.Identity.GetUserId(),
                     Content = content,
                     IsDeleted = false,
                     CreatedOn = DateTime.Now,
                     PreserveCreatedOn = true
          };
    
          this.Data.SaveChanges();
    
          this.RedirectToRoute("Show thread", new {id = post.ThreadId, name = post.Thread.Title });
    }
