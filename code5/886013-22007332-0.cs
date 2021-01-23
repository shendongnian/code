    //1. Tell EF to load Country property immediately.
    using(var db = new jQGridEntities())
    {
        customers = db.Customers.Include(c => c.Country).ToList();
    }
    //2. Put return inside using block.
    using(var db = new jQGridEntities())
    {
        customers = db.Customers.ToList();
        return Json(/*your code*/);
    }
