    public class Test{
    
        public string CatName{ get; set; }
        public string ProductnName{ get; set; }
    
    }
    List<test> testList = (from c in Context.Categories
    join p in Context.Products on c.Id equals p.Category_Id
    select new Test{ CatName= c.Name, ProductnName= p.Name}).ToList();
