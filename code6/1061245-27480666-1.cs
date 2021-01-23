    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> lstCategory = new List<Category>()
            {
                new Category(){CategoryId = 1, CategoryName = "Shoes", SubCategoryId = 2, SubCategoryName = "Baby Shoes"},
                new Category(){CategoryId = 1, CategoryName = "Shoes", SubCategoryId = 4, SubCategoryName = "Man Shoes"}
            };
    
            var grouped = lstCategory.GroupBy(obj => new { obj.CategoryId, obj.CategoryName}, (key,group)=> new {CategoryId=key.CategoryId,CategoryName=key.CategoryName,SubCategory = group});
    
        }
    }
