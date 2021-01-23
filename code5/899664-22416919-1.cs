    public class Category
    {
        public List<Category> SubCategories { get; set; }
        public int CategoryID { get; set; }
    
        public Category()
        {
            SubCategories = new List<Category>();
        }
    
        public void Add(Category cat)
        {
            SubCategories.Add(cat);
        }
    
        public static IEnumerable<Category> Recursive(Category cat)
        {
            yield return cat;
    
            foreach (Category c in cat.SubCategories)
            {
                foreach (Category cc in Recursive(c))
                    yield return cc;
            }
        }
    }
    
    ...
    
    Category top = new Category() { CategoryID = 1 };
    top.Add(new Category() { CategoryID = 2 });
    top.Add(new Category() { CategoryID = 3 });
    top.Add(new Category() { CategoryID = 3 });
    top.Add(new Category() { CategoryID = 1 });
    top.Add(new Category() { CategoryID = 2 });
    top.Add(new Category() { CategoryID = 4 });
    Category tmp = new Category() { CategoryID = 1 };
    top.Add(tmp);
    tmp.Add(new Category() { CategoryID = 1 });
    tmp.Add(new Category() { CategoryID = 2 });
    tmp.Add(new Category() { CategoryID = 6 });
    
    var test2 = Category.Recursive(top)
        .GroupBy(c => c.CategoryID).Select(g => g.First()).ToList();
