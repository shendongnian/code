    public class ClassName
    {
        public ClassName()
        {
            db =  //do whatever is needed to initialize the db context
            myQuery = from cat in db.Categories where cat.CategoryID != null select cat;
        }
    
        DataSourceContext db;
        IQueryable<Catagory> myQuery;
    
        public ActionResult Edit(long id = 0)
        {
            ViewBag.ParentCategoryID = myQuery;
            ...
        }
        
        public ActionResult Create()
        {
            ViewBag.ParentCategoryID = myQuery;
            ...
        }
    }
