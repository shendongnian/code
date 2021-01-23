    [HttpGet]
    public ActionResult CreatePost()
    {
        AddPostsVM model = new AddPostsVM();
        ConfigureEditModel(model);
        return View(model);
    }
    [HttpPost]
    public ActionResult CreatePost(AddPostsVM model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureEditModel(model); // repopulate select list
        return View(model); // return the view to correct errors
      }
      // Save and redirect
    }
    
