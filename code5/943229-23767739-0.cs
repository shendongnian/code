    var filteredProducts = db.Products.Where(p => p.Categories.Any(c => currentCategoryIdAndChildren.Contains(c.ID)))
        .Select(p => new Product_PL
        {
            id = p.ID,
            name = p.Name,
            description = p.Description,
            categories = p.Categories
                        .Select(c => new Category_PL
                        {
                            categoryid = c.ID,
                        }),
        });
