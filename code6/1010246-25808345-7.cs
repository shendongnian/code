    // Disable lazy loading.
    DatabaseContext.Configuration.LazyLoadingEnabled = false;
    var userId = ...;
    var selectedCategoryItem = DatabaseContext.Categories
            .Select(c => new
            {
                Category = c,
                SubCategories = c.SubCategories.Where(sub => !sub.Deleted),
                Parent_Category = c.Parent_Category,
                Datas = c.Datas.Where(d => 
                    !d.Deleted
                    && DatabaseContext.UserDatas.Any(ud => 
                        ud.DataId == d.DataId && ud.Id == userId)
                )
            })
            .AsEnumerable()
            .Select(a => a.Category)
            .Single(c => c.CategoryId == ParentCategoryId);
