    public ActionResult Index()
    {
        var model = from subCategory in this.Data.SubCategories
                    select new SubCategoryViewModel
                    {
                        Name = subCategory.Category.Name,
                        SubCategory = subCategory,
                        ThreadsCount = subCategory.Threads.Count(),
                        PostsCount = subCategory.Threads.SelectMany(c => c.Posts).Count(),
                    })
                    .ToList();
        return this.View(model);
    }
