      var availableCategories = new List<Category>
                {
                    new Category
                        {
                            CategoryName = "FirstCategory",
                            SubCategories = new List<Category>()
                                {
                                    new Category {CategoryName = "FirstCategoryA"},
                                    new Category {CategoryName = "FirstCategoryB"},
                                    new Category {CategoryName = "FirstCategoryC"}
                                }
                        },
                    new Category
                        {
                            CategoryName = "SecondCategory",
                            SubCategories = new List<Category>()
                                {
                                    new Category {CategoryName = "SecondCategoryA"},
                                    new Category {CategoryName = "SecondCategoryB"},
                                    new Category {CategoryName = "SecondCategoryC"}
                                }
                        }
                };
            var availableCategoryNames = availableCategories.Select(a => a.CategoryName);
            var selectedCategory = availableCategoryNames.First();
            var availableSubCategories = availableCategories.Where(a => a.CategoryName == selectedCategory)
                                                            .SelectMany(c => c.SubCategories)
                                                            .Select(s => s.CategoryName);
