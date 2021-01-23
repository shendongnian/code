    try
    {
        using (CoffeeDBEntities db = new CoffeeDBEntities())
        {
            return db.Products.Find(id);
        }
    }
    catch(Exception)
    {
        return null;
    }
