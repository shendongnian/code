    //Category implementation
    public class Category
    {
        public List<Category> SubCategories { get; set; }
        public int CategoryID { get; set; }
    
        public static int count = 0;
    
        public Category()
        {
            SubCategories = new List<Category>();
        }
    
        public void Add(Category cat)
        {
            SubCategories.Add(cat);
        }
    
        public IEnumerable<Category> AllSubCategories()
        {
            var stack = new Stack<Category>();
            stack.Push(this);
    
            while (stack.Count > 0)
            {
                Category cat = stack.Pop();
                yield return cat;
    
                foreach (Category nextCat in cat.SubCategories)
                    stack.Push(nextCat);
            }
    
        }
    
    }
    
    ...
    
    //Testing the code
    Category top = new Category() { CategoryID = 1 };
    top.Add(new Category() { CategoryID = 2 });
    top.Add(new Category() { CategoryID = 5 });
    top.Add(new Category() { CategoryID = 3 });
    top.Add(new Category() { CategoryID = 1 });
    top.Add(new Category() { CategoryID = 2 });
    top.Add(new Category() { CategoryID = 4 });
    
    Category tmp = new Category() { CategoryID = 1 };
    top.Add(tmp);
    
    tmp.Add(new Category() { CategoryID = 1 });
    tmp.Add(new Category() { CategoryID = 7 });
    tmp.Add(new Category() { CategoryID = 6 });
    
    Category tmp2 = new Category() { CategoryID = 7 };
    tmp.Add(tmp2);
    
    Category tmp3 = new Category() { CategoryID = 4 };
    tmp2.Add(tmp3);
    
    Category tmp4 = new Category() { CategoryID = 3 };
    tmp3.Add(tmp4);
    
    Category tmp5 = new Category() { CategoryID = 1 };
    tmp4.Add(tmp5);
    
    Category tmp6 = new Category() { CategoryID = 9 };
    tmp5.Add(tmp6);
    
    var Result = Category.Recursive(top).ToList().GroupBy(c => c.CategoryID).Select(g => g.First()).ToList();
