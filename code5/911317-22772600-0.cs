     public class WorkCategoriesController : ODataController
     {
            private dcMaintContext db = new dcMaintContext();
    
            // GET odata/WorkCategory
            [Queryable]
            public IQueryable<WorkCategory> GetWorkCategories()
            {
                return db.WorkCategories;
            }
    
            // GET odata/WorkCategory(5)
            [Queryable]
            public SingleResult<WorkCategory> GetWorkCategories([FromODataUri] int key)
            {
                return SingleResult.Create(db.WorkCategories.Where(workcategory => workcategory.ID == key));
            }
    ...
    }
