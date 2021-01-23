    public ActionResult Index()
    {
      var model = this.Data.Categories.Select(c => new CategoryVM
      {
        Name = c.Name,
        SubCategories = c.SubCategories.Select(s => new SubCategoryVM
        {
          Title = s.Title,
          Description = s.Description,
          ThreadsCount = s.Threads.Count,
          PostsCount = s.Threads.SelectMany(t => t.Posts).Count;
        })
      });
      return View(model);
    }
