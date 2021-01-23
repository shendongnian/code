            var categories = new OldCategory[]
            {
                new OldCategory {CategoryId = 1, SubCategoryId = 2},
                new OldCategory {CategoryId = 1, SubCategoryId = 4}
            };
            var newCategories = categories
                .GroupBy(_ => new
                {
                    Id = _.CategoryId, 
                    Name = _.CategoryName
                })
                .Select(_ => new Category
                {
                    CategoryId = _.Key.Id, 
                    CategoryName = _.Key.Name, 
                    SubCategories = _.Select(sc => new SubCategory {SubCategoryId = sc.SubCategoryId, SubCategoryName = sc.SubCategoryName})
                })
                .ToArray();
