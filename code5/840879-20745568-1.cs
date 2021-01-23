    public class CategoryViewModel
    {
        public int ID { get; set; }
        public int CategoryNameResID { get; set; }
        public string CategoryName { get; set; }
    
        public int? ParentCategory { get; set; }
        public string ParentCategoryName { get; set; }
    }   
    var categories = (from cat in Categories
    				  join res in Resources on cat.CategoryNameResID equals res.ID let categoryName = res.Text
    				  select new CategoryViewModel
    				  {
    				  	ID = cat.ID,
    					CategoryNameResID = cat.CategoryNameResID,
    					CategoryName = categoryName,
    					ParentCategory = cat.ParentCategory,	
    					ParentCategoryName = Resources.Where(r => r.ID == cat.ParentCategory).SingleOrDefault().Text
    				  }).ToList();
    				  
    				  
    foreach(var c in categories)
    {
       Console.WriteLine(c.CategoryName + " - " + c.ParentCategoryName);   
    }
    // Prints
    Standard - 
    Custom - 
    Standard Oversize - Standard
    Loose - 
    Loose 2F Set - Loose
    Loose (4” Scale) - Loose
    Loose (6” Scale) - Loose
    				  
    				  
    
