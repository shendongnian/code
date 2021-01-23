    try
    {
        using (CoffeeDBEntities db = new CoffeeDBEntities())
        {
            Product product = db.Products.Find(id);
            return product;
        }
    }
    catch(Exception)
    {
        return null;
    }
