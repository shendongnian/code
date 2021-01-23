        public class FooModel
        {
            public int CategoryId { get; set; }
            public int SubCategoryId { get; set; }
            public List<Category> Categories { get; set; }
            public List<SubCategory> SubCategories { get; set; }
        }
        public class Category
        {
            public int Id { get; set; }
            public string Description { get; set; }
        }
        public class SubCategory
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public int CategoryId { get; set; }
        }
