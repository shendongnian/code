       public ActionResult Ddl()
        {
            var model = new FooModel();
            var categories = new List<Category>();
            var subCategories = new List<SubCategory>();
            // Read from db
            categories.Add(new Category { Id = 1, Description = "Cat 1" });
            categories.Add(new Category { Id = 2, Description = "Cat 2" });
            subCategories.Add(new SubCategory { Id = 1, Description = "Sub-Cat 1", CategoryId = 1 });
            subCategories.Add(new SubCategory { Id = 2, Description = "Sub-Cat 2", CategoryId = 2 });
            model.Categories = categories;
            model.SubCategories = subCategories.Where(s => s.Id == 1).ToList();
            // initially set selected
            model.CategoryId = 1;
            model.SubCategoryId = 1;
            return View(model);
        }
        [HttpPost]
        public ActionResult Ddl(FooModel model)
        {
            var subCategoryId = model.SubCategoryId;
            // Send categories back to model etc
            ...
            return View(model);
        }
