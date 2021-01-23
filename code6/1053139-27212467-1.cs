    var model = this.Data
        .Categories
        .Select(c => new IndexCategoryViewModel
        {
            Name = c.Name,
            SubCategories = c.SubCategories,
            ThreadsCount = this.Data
                .Threads
                .Count(t => t.CategoryId == c.Id),
            PostsCount = this.Data
                .Posts
                .Count(p => this.Data
                    .Threads
                    .Any(t => p.ThreadId == t.Id && t.CategoryId == c.Id)
                ),
        })
        .ToList();
