    var model = this.Data
        .Categories
        .Select(c => new IndexCategoryViewModel
        {
            Name = c.Name,
            SubCategories = c.SubCategories,
            ThreadsCount = c.Threads.Count(),
            PostsCount = c.Threads.Sum(t => t.Posts.Count()),
        })
        .ToList();
