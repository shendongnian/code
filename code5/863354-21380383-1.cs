    [HttpGet]
    public ActionResult Create(Post post)
    {
      // Make sure the given category exists. It would be better to have a 
      // PostService with a Create action that checks this internally, e.g.
      // when you add an API or a different controller creates new posts as
      // a side effect, you don't want to copy that logic.
      var category = _categoryService.SingleById(post.CategoryId);
      if(category == null)
          throw new Exception("Invalid Category!");
      // Insert your post in the DB
      // Observe the PRG pattern: Successful POSTs should always redirect:
      return Redirect("foo"); 
    }
