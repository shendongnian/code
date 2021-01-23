    var rootCategoryItem = DatabaseContext.Categories
        .OrderBy(c => c.CategoryOrder)
        .Select(c => new Category()
        {
            SubCategories = c.SubCategories.Where(sub => !sub.Deleted)
                .OrderBy(sub => sub.CategoryOrder),
            c.CategoryId,
            c.CategoryName,
            //include any other fields needed here
        })
        .Single(c => c.CategoryId == 1);
