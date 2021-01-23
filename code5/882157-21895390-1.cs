    public IEnumerable<TopCategoryModel> Top6BlogCategories()
    {
        return db.Blogs
            .Select(b => b.Category)
            .Distinct()
            .Select(c => new TopCategoryModel
                {
                    Category = c,
                    Count = db.Blogs.Count(b => b.Category == c)
                })
            .OrderByDescending(a => a.Count)
            .Take(6);
    }
