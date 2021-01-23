    // Disable lazy loading temporary.
    var lazy = DatabaseContext.Configuration.LazyLoadingEnabled;
    DatabaseContext.Configuration.LazyLoadingEnabled = false;
    var userId = ...;
    var selectedCategoryItem = DatabaseContext.Categories
            .Select(c => new
            {
                Category = c,
                SubCategories = c.SubCategories.Where(sub => !sub.Deleted),
                Parent_Category = c.Parent_Category,
                Datas = c.Datas.Where(d => !d.Deleted
                    && db.UserDatas.Any(ud => ud.DataId == d.Id && ud.Id == userId)
                )
            })
            .AsEnumerable()
            .Select(a => a.Category)
            .Single(c => c.CategoryId == ParentCategoryId);
    // Reset.
    DatabaseContext.Configuration.LazyLoadingEnabled = lazy;
