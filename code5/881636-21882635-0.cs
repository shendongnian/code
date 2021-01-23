    public class Category
    {
        public int Id {get; set; }
        public string Name {get; set; }
        public string Description {get; set; }
    
        public List<Category> ParentCategories {get; set; }
        public List<Category> ChildCategories {get; set; }
    }
    
    public class CategoryRelationships
    {
        public int ParentCategoryId {get; set; }
        public int ChildCategoryId {get; set; }
    }
