    class PostCreateViewModel
    {
         Dictionary<string, string> Categories {get; set;}
         /// ...
    }
    [HttpGet]
    public ActionResult Create()
    {
      var categories = _categoryService.All();
      var vm = new PostCreateViewModel();
      vm.Categories = categories.ToDictionary(p => p.CategoryId.ToString());
      // etc.
      return View(vm);
    }
